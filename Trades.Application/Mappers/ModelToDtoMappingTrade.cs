using AutoMapper;
using Trades.Application.Dtos;
using Trades.Domain.Entitys;

namespace Trades.Application.Mappers
{
    public class ModelToDtoMappingTrade : Profile
    {
        public ModelToDtoMappingTrade()
        {
            PortfolioDtoMap();
        }

        private void PortfolioDtoMap()
        {
            CreateMap<Trade, TradeDto>()
                .ForMember(dest => dest.ClientSector, opt => opt.MapFrom(x => x.ClientSector))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(x => x.Value));
        }
    }
}
