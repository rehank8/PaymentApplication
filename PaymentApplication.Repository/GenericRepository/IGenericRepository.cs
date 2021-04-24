using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace PaymentApplication.Repository
{
   public interface IGenericRepository<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllBy(Expression<Func<T, bool>> predicate);
        T GetBy(Expression<Func<T, bool>> predicate);
        T GetById(string id);
        T Add(T entity);
        void Update(T entity);
        void Delete(string id);
    }
}
