using Trades.Domain.Core.Interfaces.Repositorys;
using Trades.Domain.Core.Interfaces.Services;
using Trades.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Trades.Domain.Services
{
    public class ServiceTradeCategory : ServiceBase<TradeCategory>, IServiceTradeCategory
    {
        private readonly IRepositoryTradeCategory _repositoryTradeCategory;

        public ServiceTradeCategory(IRepositoryTradeCategory repositoryTradeCategory)
            : base(repositoryTradeCategory)
        {
            _repositoryTradeCategory = repositoryTradeCategory;
        }

        public async Task<IEnumerable<string>> GetTradeCategories(IList<Trade> tradesDto)
        {
            var tradeCategories = new List<string>();

            foreach (var trades in tradesDto)
            {
                var tradeCategory = await _repositoryTradeCategory.GetTradeCategories(trades);

                if (tradeCategory != null)
                    tradeCategories.Add(tradeCategory.Category);
            }

            return tradeCategories;
        }
    }
}