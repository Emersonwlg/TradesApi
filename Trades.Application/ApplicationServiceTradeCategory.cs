using AutoMapper;
using Trades.Application.Dtos;
using Trades.Application.Interfaces;
using Trades.Domain.Core.Interfaces.Services;
using Trades.Domain.Entitys;
using System.Collections.Generic;

namespace Trades.Application
{
    public class ApplicationServiceTradeCategory : IApplicationServiceTradeCategory
    {
        private readonly IServiceTradeCategory serviceTradeCategory;
        private readonly IMapper mapper;

        public ApplicationServiceTradeCategory(
            IServiceTradeCategory serviceCliente,
            IMapper mapper)
        {
            this.serviceTradeCategory = serviceCliente;
            this.mapper = mapper;
        }
       
        public IEnumerable<string> GetTradeCategories(IList<PortfolioDto> listPortfolioDto)
        {
            var portolios = mapper.Map<IList<Portfolio>>(listPortfolioDto);
            return serviceTradeCategory.GetTradeCategories(portolios);
        }

        public TradeCategoryDto GetById(int id)
        {
            var tradeCategory = serviceTradeCategory.GetById(id);
            var tradeCategoryDto = mapper.Map<TradeCategoryDto>(tradeCategory);

            return tradeCategoryDto;
        }

        public void Add(TradeCategoryDto tradeCategoryDto)
        {
            var tradeCategory = mapper.Map<TradeCategory>(tradeCategoryDto);
            serviceTradeCategory.Add(tradeCategory);
        }


        public void Remove(TradeCategoryDto tradeCategoryDto)
        {
            var tradeCategory = mapper.Map<TradeCategory>(tradeCategoryDto);
            serviceTradeCategory.Remove(tradeCategory);
        }

        public void Update(TradeCategoryDto tradeCategoryDto)
        {
            var tradeCategory = mapper.Map<TradeCategory>(tradeCategoryDto);
            serviceTradeCategory.Update(tradeCategory);
        }
    }
}
