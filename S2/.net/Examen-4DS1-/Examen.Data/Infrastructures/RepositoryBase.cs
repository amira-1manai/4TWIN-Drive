using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Examen.Data.Infrastructures
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private IDatabaseFactory _dbFactory;
        DbSet<T> dbset { get { return _dbFactory.DataContext.Set<T>();}}
        public RepositoryBase(IDatabaseFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public virtual void Add(T entity)
        {
            dbset.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);
        }

        // Delete(p=>p.price<100)
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            dbset.RemoveRange(dbset.Where(where));
        }

        public virtual T Get(Expression<Func<T, bool>> where)
        {
            return dbset.FirstOrDefault(where);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbset.AsEnumerable();
        }

        public T GetById(long Id)
        {
            return dbset.Find(Id);
        }

        public T GetById(string Id)
        {
            return dbset.Find(Id);
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where = null)
        {
            if(where!=null)
              return dbset.Where(where).AsEnumerable();
            return dbset.AsEnumerable();//else
        }

        public void Update(T entity)
        {
            dbset.Update(entity);
        }
    }
}
