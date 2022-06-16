using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trades.Application;
using Trades.Application.Interfaces;
using Trades.Application.Mappers;
using Trades.Domain.Core.Interfaces.Repositorys;
using Trades.Domain.Core.Interfaces.Services;
using Trades.Domain.Services;
using Trades.Infrastructure.Data.Repositorys;

namespace Trades.Infrastructure.CrossCutting.IOC
{
    public static class DependecyInjection
    {
        public static void DependencyInjector(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);

            RegisterApplications(services);
            RegisterServices(services);
            RegistrerRepositories(services);
            RegisterMapping(services);
        }

        private static void RegisterApplications(IServiceCollection services)
        {
            services.AddScoped<IApplicationServiceTradeCategory, ApplicationServiceTradeCategory>();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IApplicationServiceTradeCategory, ApplicationServiceTradeCategory>();
            services.AddScoped<IServiceTradeCategory, ServiceTradeCategory>();
        }

        private static void RegistrerRepositories(IServiceCollection services)
        {
            services.AddScoped<IRepositoryTradeCategory, RepositoryTradeCategory>();
        }

        private static void RegisterMapping(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DtoToModelMappingTrade());
                mc.AddProfile(new ModelToDtoMappingTrade());
                mc.AddProfile(new DtoToModelMappingTradeCategory());
                mc.AddProfile(new ModelToDtoMappingTradeCategory());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}