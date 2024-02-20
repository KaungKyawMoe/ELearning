using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork
{
    public interface IRepository<TEntity>
    {
        public Task<IEnumerable<TEntity>> GetAll();

        public Task<TEntity> GetById(string id);

        public Task<bool> Create(TEntity entity);

        public Task<bool> Update(TEntity entity);

        public Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);

        public Task<int> CommitAsync();
    }

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbContext dbContext;

        private DbSet<TEntity> set;

        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.set = this.dbContext.Set<TEntity>();
        }

        public async Task<bool> Create(TEntity entity)
        {
            await this.set.AddAsync(entity);
            return true;
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await this.set.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await this.set.ToListAsync();
        }

        public async Task<TEntity> GetById(string id)
        {
            return await this.set.FindAsync(id);
        }

        public async Task<bool> Update(TEntity entity)
        {
            this.set.Update(entity);
            return true;
        }

        public async Task<int> CommitAsync()
        {
            return await this.dbContext.SaveChangesAsync();
        }
    }
}
