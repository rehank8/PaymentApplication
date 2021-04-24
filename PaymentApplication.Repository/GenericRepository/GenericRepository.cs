using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PaymentApplication.Repository
{
  public  class GenericRepository<T> : IGenericRepository<T>, IDisposable where T : class
    {
        protected DbContext _db;
        protected DbSet<T> ds;

        public GenericRepository(DbContext db, bool isMoc = false)
        {
            _db = db;
            ds = _db.Set<T>();
            if (!isMoc)
            {
                _db.ChangeTracker.LazyLoadingEnabled = false;
            }
        }


        public virtual IEnumerable<T> GetAll()
        {
            var dsTemp = ds.ToList();
            return dsTemp;
        }

        public IEnumerable<T> GetAllBy(Expression<Func<T, bool>> predicate)
        {
            return _db.Set<T>().Where(predicate).AsEnumerable<T>();
        }

        public virtual T GetById(string id)
        {
            return ds.Find(id);
        }

        public T GetBy(Expression<Func<T, bool>> predicate)
        {
            return _db.Set<T>().Where(predicate).FirstOrDefault<T>();
        }

        public virtual T Add(T entity)
        {
            ds.Add(entity);
            _db.SaveChanges();
            return entity;
        }

        public virtual void Update(T entity)
        {
            _db.Entry<T>(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public virtual void Delete(string id)
        {
            T entity = ds.Find(id);
            _db.Set<T>().Remove(entity);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
