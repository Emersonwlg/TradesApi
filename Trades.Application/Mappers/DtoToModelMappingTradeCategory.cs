using AutoMapper;
using Trades.Application.Dtos;
using Trades.Domain.Entitys;

namespace Trades.Application.Mappers
{
    public class DtoToModelMappingTradeCategory: Profile
    {
        public DtoToModelMappingTradeCategory()
        {
            TradeCategoryMap();
        }

        private void TradeCategoryMap()
        {
            CreateMap<TradeCategoryDto, TradeCategory>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(x => x.Category))
                .ForMember(dest => dest.ClientSector, opt => opt.MapFrom(x => x.ClientSector))
                .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(x => x.CreationDate))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(x => x.Value));
        }
    }
}
