using ASC.DataAccess.Interfaces;
using ASC.Model.BaseTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASC.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<string, object> _repositories = new();
        private readonly DbContext _dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CommitTransaction()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public IRepository<T> Repository<T>() where T : BaseEntity
        {
            var type = typeof(T).Name;
            if (!_repositories.ContainsKey(type))
            {
                var repositoryInstance = (IRepository<T>)Activator.CreateInstance(
                    typeof(Repository<>).MakeGenericType(typeof(T)), _dbContext);
                _repositories[type] = repositoryInstance;
            }
            return (IRepository<T>)_repositories[type];
        }
    }
}
