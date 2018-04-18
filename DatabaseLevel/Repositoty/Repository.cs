using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using DatabaseLevel.Entities;

namespace DatabaseLevel.Repositoty
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private shopContext db;

        public Repository()
        {
            db = new shopContext();
        }

        public IEnumerable<T> GetAll() => db.Set<T>().ToList();

        public T Add(T item)
        {
            return db.Set<T>().Add(item);
        }

        public void Update(T item)
        {
            db.Set<T>().Attach(item);
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(T item)
        {
            db.Set<T>().Remove(item);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db?.Dispose();
        }

        public T Find(Expression<Func<T, bool>> match)
        {
            return db.Set<T>().SingleOrDefault(match);
        }
    }
}
