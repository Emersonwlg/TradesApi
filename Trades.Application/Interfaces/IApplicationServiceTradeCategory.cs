using Trades.Application.Dtos;
using System.Collections.Generic;

namespace Trades.Application.Interfaces
{
    public interface IApplicationServiceTradeCategory
    {
        void Add(TradeCategoryDto tradeCategoryDto);

        void Update(TradeCategoryDto tradeCategoryDto);

        void Remove(TradeCategoryDto tradeCategoryDto);

        IEnumerable<string> GetTradeCategories(IList<PortfolioDto> portfolioDto);

        TradeCategoryDto GetById(int id);
    }
}