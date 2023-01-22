using EFUpskilling.Entities;
using EFUpskilling.Repositories;
using EFUpskilling.Services;
using EFUpskilling.Services.Impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

public class Program
{
    public static void Main(string[] args)
    {
        AppDbContext Context = new();
        IRepository<Customer> repositoryCustomer = new Repository<Customer>(Context);
        IRepository<Product> repositoryProduct = new Repository<Product>(Context);
        IRepository<Purchase> repositoryPurchase = new Repository<Purchase>(Context);
        IPersistance persistance = new Persistance(Context);
        // service
        ICustomerService customerService = new CustomerService(repositoryCustomer, persistance);
        IProductService productService = new ProductService(repositoryProduct, persistance);
        IPurchaseService purchaseService = new PurchaseService(persistance, repositoryPurchase, productService);

        Purchase purchase1 = new Purchase
        {
            TransDate = DateTime.Now,
            CustomerId = Guid.Parse("433bd778-9c0d-4ea3-8d8f-08dafc7a740b"),
            PurchaseDetail = new List<PurchaseDetail>
            {
                new() {ProductId = Guid.Parse("ce4a5764-fd5a-4050-b0c7-08dafc7adb46"), Qty = 5},
                new() {ProductId = Guid.Parse("0d9fc65e-5eb4-4ac7-3ff7-08dafc7aed69"), Qty = 5}
            }
        };

        purchaseService.CreateNewTransaction(purchase1);

        Customer customer1 = new Customer
        {
            CustomerName = "Yasuo",
            Address = "Jalan kimigakure",
            Email = "yasuo@gmail.com",
            MobilePhone = "0234828348"
        };

        Product product = new Product
        {
            ProductName = "Nextar",
            ProductPrice = 2000,
            Stock = 10
        };


        //productService.CreateNewProduct(product);

        //var pro = productService.FindProductById(Guid.Parse("561059bc-d5d9-4e3a-045b-08daf9d3d658"));
        //var res = new Product { ProductName = pro?.ProductName, ProductPrice = (long)(pro?.ProductPrice), Id = pro.Id, Stock = pro.Stock };
        //Console.WriteLine(res.ToString());


        //var transaction = Context.Database.BeginTransaction();
        //purchasingMethod(Context, transaction);

        //var purchase = Context?.Purchases?
        //    .Include(p => p.Customer)
        //    .Include(p => p.PurchaseDetail)
        //    .ThenInclude(pd => pd.Product)
        //    .FirstOrDefault(p => p.Id.Equals(Guid.Parse("b6dee3bf-a040-4774-0001-08daf962c882")));

        //Console.WriteLine(purchase);
    }

    private static void purchasingMethod(AppDbContext Context, IDbContextTransaction transaction)
    {
        try
        {
            var purchase = new Purchase()
            {
                TransDate = DateTime.Now,
                CustomerId = Guid.Parse("adf5c934-51f0-4956-5f54-08daf9285a6a"),
                PurchaseDetail = new List<PurchaseDetail>
                {
                    new() { ProductId = Guid.Parse("50939c0e-3f4a-496b-094a-08daf961558d"), Qty = 2 },
                    new() { ProductId = Guid.Parse("eef00732-dc58-4a70-e23a-08daf961327b"), Qty = 3 }
                }
            };

            Context?.Purchases?.Add(purchase);
            Context?.SaveChanges();

            foreach (var item in purchase.PurchaseDetail)
            {
                var product = Context?.Products?.FirstOrDefault(product => product.Id.Equals(item.ProductId));
                if (product != null) product.Stock -= item.Qty;
            }

            Context?.SaveChanges();

            transaction.Commit();


        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            transaction.Rollback();
            throw;
        }
    }
}