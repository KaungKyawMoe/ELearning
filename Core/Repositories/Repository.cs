using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class 
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(string id);

        Task Create(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(string id);
    }

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _dbContext;
        public Repository(DbContext dbContext){
            _dbContext = dbContext;
        }

        public async Task Create(TEntity entity)
        {
           await _dbContext.Set<TEntity>().AddAsync(entity);
           await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            TEntity entity = await GetById(id);
            _dbContext.Remove<TEntity>(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> GetById(string id)
        {
            return await _dbContext.FindAsync<TEntity>(id);
        }

        public async Task Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
