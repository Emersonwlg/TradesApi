using Trades.Domain.Core.Interfaces.Repositorys;
using Trades.Domain.Core.Interfaces.Services;
using Trades.Domain.Entitys;
using System.Collections.Generic;

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

        public IEnumerable<string> GetTradeCategories(IList<Portfolio> listPortfolio)
        {
            var tradeCategories = new List<string>();

            foreach (var portfolio in listPortfolio)
            {
                var tradeCategory = _repositoryTradeCategory.GetTradeCategories(portfolio);

                if (tradeCategory != null)
                    tradeCategories.Add(tradeCategory.Category);
            }

            return tradeCategories;
        }
    }
}