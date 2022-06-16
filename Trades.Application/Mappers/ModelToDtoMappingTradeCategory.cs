using AutoMapper;
using Trades.Application.Dtos;
using Trades.Domain.Entitys;

namespace Trades.Application.Mappers
{
    public class ModelToDtoMappingTradeCategory: Profile
    {

        public ModelToDtoMappingTradeCategory()
        {
            TradeCategoryDtoMap();
        }

        private void TradeCategoryDtoMap()
        {
            CreateMap<TradeCategory, TradeCategoryDto>()
               .ForMember(dest => dest.Category, opt => opt.MapFrom(x => x.Category))
               .ForMember(dest => dest.ClientSector, opt => opt.MapFrom(x => x.ClientSector))
               .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(x => x.CreationDate))
               .ForMember(dest => dest.Value, opt => opt.MapFrom(x => x.Value));
        }
    }
}
