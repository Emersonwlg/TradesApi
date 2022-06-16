using Trades.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Trades.Application.Interfaces
{
    public interface IApplicationServiceTradeCategory
    {
        Task Add(TradeCategoryDto tradeCategoryDto);

        Task Update(TradeCategoryDto tradeCategoryDto);

        Task Remove(TradeCategoryDto tradeCategoryDto);

        Task<IEnumerable<string>> GetTradeCategories(IList<TradeDto> tradesDto);

        Task<TradeCategoryDto> GetById(Guid id);

        Task<IEnumerable<TradeCategoryDto>> GetAll();
    }
}