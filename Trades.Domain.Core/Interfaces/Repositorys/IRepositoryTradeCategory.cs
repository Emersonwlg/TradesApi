using Trades.Domain.Entitys;

namespace Trades.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryTradeCategory : IRepositoryBase<TradeCategory>
    {
        TradeCategory GetTradeCategories(Portfolio portfolio);
    }
}
