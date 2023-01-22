using EFUpskilling.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFUpskilling.Repositories
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Purchase>? Purchases { get; set; }
        public DbSet<PurchaseDetail>? PurchaseDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;user=sa;password=123;Database=SQL_EFCORE;Trusted_Connection=false;MultipleActiveResultSets=true;TrustServerCertificate=True");
        }
    }
}
