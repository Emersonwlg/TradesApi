using AutoMapper;
using Trades.Application.Dtos;
using Trades.Domain.Entitys;

namespace Trades.Application.Mappers
{
    public class DtoToModelMappingTrade : Profile
    {
        public DtoToModelMappingTrade()
        {
            PortfolioMap();
        }

        private void PortfolioMap()
        {
            CreateMap<TradeDto, Trade>()
                .ForMember(dest => dest.ClientSector, opt => opt.MapFrom(x => x.ClientSector))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(x => x.Value));
        }
    }
}
