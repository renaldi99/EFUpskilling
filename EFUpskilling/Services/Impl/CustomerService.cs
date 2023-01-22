using EFUpskilling.Entities;
using EFUpskilling.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFUpskilling.Services.Impl
{
    public class CustomerService : ICustomerService
    {
        private readonly IPersistance? persistance;
        private readonly IRepository<Customer> repository;

        public CustomerService(IRepository<Customer> repository, IPersistance? persistance)
        {
            this.persistance = persistance;
            this.repository = repository;
        }

        public Customer? CreateNewCustomer(Customer customer)
        {
            try
            {
                var res = repository.Save(customer);
                persistance?.SaveChanges();
                if (res == null) Console.WriteLine("Failed");
                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public Customer? FindCustomerById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
