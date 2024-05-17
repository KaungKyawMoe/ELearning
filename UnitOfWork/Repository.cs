using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

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

        public Task<IEnumerable<TEntity>> ExecuteStoredProcedure(string name,IDictionary<string,object> parameters);
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

        public async Task<IEnumerable<TEntity>> ExecuteStoredProcedure(string name, IDictionary<string,object> parameters)
        {
            List<TEntity> entities = new List<TEntity>();

            using(var con = this.dbContext.Database.GetDbConnection())
            {
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                var cmd = con.CreateCommand();
                cmd.CommandText = name;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                
                foreach(var param in parameters)
                {
                    var sqlParam = cmd.CreateParameter();
                    sqlParam.ParameterName = param.Key;
                    sqlParam.Value = param.Value;

                    cmd.Parameters.Add(sqlParam);
                }

                var result = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(result);

                if(con.State != ConnectionState.Closed)
                {
                    con.Close();
                }

                return ToEntityList(dt);
            }
        }

        public IEnumerable<TEntity> ToEntityList(DataTable dt)
        {
            IList<TEntity> entities = new List<TEntity>();

            foreach (DataRow dr in dt.Rows)
            {
                var entity = (TEntity) Activator.CreateInstance(typeof(TEntity));
                var properties = typeof(TEntity).GetProperties();
                foreach (var prop in properties)
                {
                    if (dr.Table.Columns.Contains(prop.Name.ToLower()))
                    {
                        prop.SetValue(entity, dr[prop.Name.ToLower()]);
                    }
                }

                entities.Add(entity);
            }

            return entities.Any() ? entities : Enumerable.Empty<TEntity>();
        }
    }
}
