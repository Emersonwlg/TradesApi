using Trades.Domain.Core.Interfaces.Repositorys;
using Trades.Domain.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Trades.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            this.repository = repository;
        }

        public async Task Add(TEntity entity)
        {
            await repository.Add(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await repository.GetAll();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await repository.GetById(id);
        }

        public async Task Remove(TEntity entity)
        {
            await repository.Remove(entity);
        }

        public async Task Update(TEntity entity)
        {
            await repository.Update(entity);
        }
    }
}