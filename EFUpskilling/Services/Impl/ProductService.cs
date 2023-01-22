using EFUpskilling.Entities;
using EFUpskilling.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFUpskilling.Services.Impl
{
    public class ProductService : IProductService
    {
        private readonly IPersistance? persistance;
        private readonly IRepository<Product> repository;

        public ProductService(IRepository<Product> repository, IPersistance? persistance)
        {
            this.persistance = persistance;
            this.repository = repository;
        }

        public Product? CreateNewProduct(Product product)
        {
            try
            {
                var res = repository.Save(product);
                persistance?.SaveChanges();
                if (res == null) Console.WriteLine("Failed");
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Product? FindProductById(Guid id)
        {
            try
            {
                var res = repository.FindById(id);
                if (res is null) Console.WriteLine("Not Found");
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
