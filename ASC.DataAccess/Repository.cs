using ASC.DataAccess.Interfaces;
using ASC.Model.BaseTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASC.DataAccess
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly DbContext dbContext;

        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            entity.UpdatedDate = DateTime.UtcNow;
            var result = await dbContext.Set<T>().AddAsync(entity);
            return result.Entity;
        }

        public void Update(T entity)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            dbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            entity.IsDeleted = true;
            dbContext.Set<T>().Update(entity);
        }

        public async Task<T> FindAsync(string partitionKey, string rowKey)
        {
            return await dbContext.Set<T>().FindAsync(partitionKey, rowKey);
        }

        public async Task<IEnumerable<T>> FindAllByPartitionKeyAsync(string partitionKey)
        {
            return await dbContext.Set<T>().Where(t => t.PatititonKey == partitionKey).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }
    }
}