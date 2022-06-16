using Trades.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Trades.Domain.Core.Interfaces.Services
{
    public interface IServiceTradeCategory : IServiceBase<TradeCategory>
    {
        Task<IEnumerable<string>> GetTradeCategories(IList<Trade> tradesDto);
    }
}