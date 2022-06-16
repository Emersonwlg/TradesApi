using Trades.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Trades.Domain.Core.Interfaces.Services
{
    public interface IServiceTradeCategory : IServiceBase<TradeCategory>
    {
        IEnumerable<string> GetTradeCategories(IList<Portfolio> listPortfolio);
    }
}