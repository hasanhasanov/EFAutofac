using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace WebDoctor.Data
{
    public interface IRepository<T> where T : class
    {
        int Count();
        T GetById(int id);
        IQueryable<T> GetAll();
        IEnumerable<T> GetList();
        bool Create(T entity);
        bool Update(T entity);
        bool UpdateDelete(T entity);
        bool Delete(T entity);
    }
}
