using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork
{
    public interface IUnitOfWork<TContext> where TContext : DbContext
    {
        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        Task<bool> CommitAsync();

        Task<bool> RollbackAsync();
    }

    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext: DbContext
    {
        public TContext _dbContext;
        public UnitOfWork(TContext dbContext) {
            _dbContext= dbContext;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return new Repository<TEntity>(_dbContext);
        }

        public async Task<bool> CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RollbackAsync()
        {
            await _dbContext.DisposeAsync();
            return true;
        }
    }
}
