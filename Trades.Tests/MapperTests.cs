using AutoMapper;
using NUnit.Framework;
using Trades.Application.Mappers;

namespace Trades.Tests
{
    [TestFixture]
    public class MapperTests
    {
        [Test]
        public void AutoMapperDtoToModelTradeCategory_Configuration_IsValid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<DtoToModelMappingTradeCategory>());
            config.AssertConfigurationIsValid();
        }

        [Test]
        public void AutoMapperModelToDtoTradeCategory_Configuration_IsValid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ModelToDtoMappingTradeCategory>());
            config.AssertConfigurationIsValid();
        }

        [Test]
        public void AutoMapperDtoToModelTrade_Configuration_IsValid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<DtoToModelMappingTrade>());
            config.AssertConfigurationIsValid();
        }

        [Test]
        public void AutoMapperModelToDto_Configuration_IsValid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ModelToDtoMappingTrade>());
            config.AssertConfigurationIsValid();
        }
    }
}
