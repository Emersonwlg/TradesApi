using System.Threading.Tasks;
using Trades.Domain.Entitys;

namespace Trades.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryTradeCategory : IRepositoryBase<TradeCategory>
    {
        Task<TradeCategory> GetTradeCategories(Trade trade);
    }
}
