using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFUpskilling.Repositories
{
    public interface IPersistance
    {
        void SaveChanges();
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
