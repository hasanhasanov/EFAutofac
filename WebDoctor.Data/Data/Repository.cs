using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace WebDoctor.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Repository'ni kullanan her class _context adında bir DByi ve Table adında bir tabloyu kullanacaktır.

        private readonly IDoctorDbContext _context;
        private IDbSet<T> _entities;

        public Repository(IDoctorDbContext context)
        {
            this._context = context;
            this._entities = context.Set<T>();
        }

        //_entities --> Table
        protected IDbSet<T> Table => this._entities ?? (this._entities = this._context.Set<T>());

        #endregion


        public int Count()
        {
            return this.Table.Count();
        }
        public IQueryable<T> GetAll()
        {
            return this.Table.AsQueryable<T>();
        }

        public T GetById(int id)
        {
            return this.Table.Find(id);
        }
        public bool Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Model can not be null!");
            }

            try
            {
                this.Table.Add(entity);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw new ArgumentException("An error occurred while adding!");
                return false;
            }
        }

        public bool Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Model can not be null!");
            }
            try
            {
                this._context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw new ArgumentException("An error occurred during the update!");
                return false;
            }
        }

        public bool Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Model can not be null!");
            }

            try
            {
                this.Table.Remove(entity);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw new ArgumentException("Deletion failed!");
            }
        }

        public bool UpdateDelete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Model can not be null!");
            }
            try
            {
                this._context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw new ArgumentException("An error occurred during the update!");
                return false;
            }
        }

        public IEnumerable<T> GetList()
        {
            return this.Table.ToList();
        }
    }
}
