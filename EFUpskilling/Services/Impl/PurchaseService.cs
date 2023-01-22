using EFUpskilling.Entities;
using EFUpskilling.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFUpskilling.Services.Impl
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPersistance persistance;
        private readonly IRepository<Purchase> repository;
        private readonly IProductService productService;

        public PurchaseService(IPersistance persistance, IRepository<Purchase> repository, IProductService productService)
        {
            this.persistance = persistance;
            this.repository = repository;
            this.productService = productService;
        }

        public Purchase? CreateNewTransaction(Purchase purchase)
        {
            try
            {
                persistance.BeginTransaction();
                var res = repository.Save(purchase);
                persistance.SaveChanges(); // setiap perubahan save
                if (purchase.PurchaseDetail is not null)
                {
                    foreach (PurchaseDetail item in purchase.PurchaseDetail)
                    {
                        var product = productService.FindProductById(item.ProductId);
                        if (product != null)
                        {
                            if (product.Stock <= 0)
                            {
                                Console.WriteLine("Product Habis");
                                throw new Exception();
                            }

                            var pas = product.Stock -= item.Qty;
                            if (pas <= 0)
                            {
                                Console.WriteLine("Product Tidak Mencukupi");
                                throw new Exception();
                            }

                            persistance.SaveChanges(); // setiap perubahan save

                        }
                    }
                }

                persistance.Commit(); // commit hasil akhir
                return res;
            }
            catch (Exception)
            {
                persistance.Rollback();
                throw;
            }
        }
    }
}
