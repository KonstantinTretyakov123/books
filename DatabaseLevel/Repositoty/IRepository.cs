using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLevel.Repositoty
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        IEnumerable<T> GetAll();
        T Add(T entity);
        void Update(T item);
        void Delete(T item);
        void Save();
        T Find(Expression<Func<T, bool>> match);
    }
}
