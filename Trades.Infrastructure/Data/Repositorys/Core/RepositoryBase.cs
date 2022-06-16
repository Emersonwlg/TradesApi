using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Trades.Domain.Core.Interfaces.Repositorys;

namespace Trades.Infrastructure.Data.Repositorys
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly SqlContext _sqlContext;
        protected readonly DbSet<TEntity> DbSet;

        public RepositoryBase(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
            DbSet = sqlContext.Set<TEntity>();
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task Add(TEntity entity)
        {
            try
            {
                DbSet.Add(entity);
                await SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task Remove(TEntity entity)
        {
            try
            {
                DbSet.Remove(entity);
                await SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(TEntity entity)
        {
            try
            {
                DbSet.Update(entity);
                await SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> SaveChanges()
        {
            return await _sqlContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _sqlContext?.Dispose();
        }
    }
}