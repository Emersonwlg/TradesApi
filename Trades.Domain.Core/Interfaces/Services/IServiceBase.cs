using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Trades.Domain.Core.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        Task Add(TEntity entity);

        Task Update(TEntity entity);

        Task Remove(TEntity entity);

        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetById(Guid id);
    }
}