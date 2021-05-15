using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        T Add(T entity);
        T Update(T entity);
        T Get(Guid id);
        ICollection<T> GetAll();
        ICollection<T> Find(Expression<Func<T, bool>> predicate);
        void Delete(T entity);
        void SaveChanges();
    }
}
