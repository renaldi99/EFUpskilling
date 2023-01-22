using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFUpskilling.Repositories
{
    internal class Persistance : IPersistance
    {
        private readonly AppDbContext appDbContext;

        public Persistance(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }

        public void BeginTransaction()
        {
            appDbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            appDbContext.Database.CommitTransaction();
        }

        public void Rollback()
        {
            appDbContext.Database.RollbackTransaction();
        }

        public void SaveChanges()
        {
            appDbContext.SaveChanges();
        }
    }
}
