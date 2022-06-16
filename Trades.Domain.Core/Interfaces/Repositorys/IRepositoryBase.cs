using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Trades.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task Add(TEntity entity);

        Task Update(TEntity entity);

        Task Remove(TEntity entity);

        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetById(Guid id);

        Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
    }
}