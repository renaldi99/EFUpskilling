using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFUpskilling.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext? appDbContext;

        public Repository(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }

        public void Delete(T entity)
        {
            appDbContext?.Set<T>().Remove(entity);
        }

        public IEnumerable<T>? FindAll()
        {
            return appDbContext?.Set<T>().AsEnumerable();
        }

        public IEnumerable<T>? FindAll(Func<T, bool> predicate)
        {
            return appDbContext?.Set<T>().Where(predicate);
        }

        public T? FindBy(Func<T, bool> predicate)
        {
            return appDbContext?.Set<T>().FirstOrDefault(predicate);
        }

        public T? FindById(Guid id)
        {
            return appDbContext?.Set<T>().Find(id);
        }

        public T? Save(T entity)
        {
            var res = appDbContext?.Set<T>().Add(entity);
            return res?.Entity;

        }

        public void Update(T entity)
        {
            appDbContext?.Set<T>().Update(entity);
        }
    }
}
