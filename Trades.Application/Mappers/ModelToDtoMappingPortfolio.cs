using AutoMapper;
using Trades.Application.Dtos;
using Trades.Domain.Entitys;

namespace Trades.Application.Mappers
{
    public class ModelToDtoMappingPortfolio : Profile
    {

        public ModelToDtoMappingPortfolio()
        {
            PortfolioDtoMap();
        }

        private void PortfolioDtoMap()
        {
            CreateMap<Portfolio, PortfolioDto>()
                .ForMember(dest => dest.ClientSector, opt => opt.MapFrom(x => x.ClientSector))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(x => x.Value));
        }
    }
}
