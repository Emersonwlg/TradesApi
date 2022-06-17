using AutoMapper;
using Trades.Application.Dtos;
using Trades.Application.Interfaces;
using Trades.Domain.Core.Interfaces.Services;
using Trades.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Trades.Application
{
    public class ApplicationServiceTradeCategory : IApplicationServiceTradeCategory
    {
        private readonly IServiceTradeCategory serviceTradeCategory;
        private readonly IMapper mapper;

        public ApplicationServiceTradeCategory(
            IServiceTradeCategory serviceTradeCategory,
            IMapper mapper)
        {
            this.serviceTradeCategory = serviceTradeCategory;
            this.mapper = mapper;
        }
       
        public async Task<IEnumerable<string>> GetTradeCategories(IList<TradeDto> tradesDto)
        {
            var portolios = mapper.Map<IList<TradeDto>, IList<Trade>>(tradesDto);
            return await serviceTradeCategory.GetTradeCategories(portolios);
        }

        public async Task<TradeCategoryDto> GetById(Guid id)
        {
            var tradeCategory = await serviceTradeCategory.GetById(id);
            var tradeCategoryDto = mapper.Map<TradeCategoryDto>(tradeCategory);

            return tradeCategoryDto;
        }

        public async Task Add(TradeCategoryDto tradeCategoryDto)
        {
            var tradeCategory = mapper.Map<TradeCategory>(tradeCategoryDto);
            await serviceTradeCategory.Add(tradeCategory);
        }


        public async Task Remove(TradeCategoryDto tradeCategoryDto)
        {
            var tradeCategory = mapper.Map<TradeCategory>(tradeCategoryDto);
            await serviceTradeCategory.Remove(tradeCategory);
        }

        public async Task Update(TradeCategoryDto tradeCategoryDto)
        {
            var tradeCategory = mapper.Map<TradeCategory>(tradeCategoryDto);
            await serviceTradeCategory.Update(tradeCategory);
        }

        public async Task<IEnumerable<TradeCategoryDto>> GetAll()
        {
            var tradeCategories = await serviceTradeCategory.GetAll();
            var tradeCategoriesDto = mapper.Map<IEnumerable<TradeCategoryDto>>(tradeCategories);

            return tradeCategoriesDto;
        }
    }
}
