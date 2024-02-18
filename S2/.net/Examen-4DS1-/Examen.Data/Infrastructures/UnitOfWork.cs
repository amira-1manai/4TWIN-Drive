using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.Data.Infrastructures
{
    public class UnitOfWork:IUnitOfWork
    {
        readonly IDatabaseFactory _dbFactory;
        public UnitOfWork(IDatabaseFactory dbFactory) { _dbFactory = dbFactory; }
        public void Commit() { _dbFactory.DataContext.SaveChanges(); }
        public IRepositoryBase<T> getRepository<T>() where T : class
        {
            return new RepositoryBase<T>(_dbFactory);
        }
        public void Dispose() { _dbFactory.DataContext.Dispose(); }
    }
}
