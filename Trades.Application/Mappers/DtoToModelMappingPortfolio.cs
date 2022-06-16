﻿using AutoMapper;
using Trades.Application.Dtos;
using Trades.Domain.Entitys;

namespace Trades.Application.Mappers
{
    public class DtoToModelMappingPortfolio : Profile
    {
        public DtoToModelMappingPortfolio()
        {
            PortfolioMap();
        }

        private void PortfolioMap()
        {
            CreateMap<PortfolioDto, Portfolio>()
                .ForMember(dest => dest.ClientSector, opt => opt.MapFrom(x => x.ClientSector))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(x => x.Value));
        }
    }
}
