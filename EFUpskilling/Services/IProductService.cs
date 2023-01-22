using EFUpskilling.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFUpskilling.Services
{
    public interface IProductService
    {
        Product? CreateNewProduct(Product product);
        Product? FindProductById(Guid id);
    }
}
