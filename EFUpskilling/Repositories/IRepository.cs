using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFUpskilling.Repositories
{
    public interface IRepository<T>
    {
        T? Save(T entity);
        T? FindById(Guid id);
        T? FindBy(Func<T, bool> predicate);
        IEnumerable<T>? FindAll();
        IEnumerable<T>? FindAll(Func<T, bool> predicate);
        void Update(T entity);
        void Delete(T entity);
    }
}
