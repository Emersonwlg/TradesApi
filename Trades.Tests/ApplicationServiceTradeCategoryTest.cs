using AutoFixture;
using AutoMapper;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Trades.Application;
using Trades.Application.Dtos;
using Trades.Domain.Core.Interfaces.Services;
using Trades.Domain.Entitys;

namespace trades.tests
{
    [TestFixture]
    public class ApplicationServiceTradeCategorytest
    {
        private static Fixture _fixture;
        private Mock<IServiceTradeCategory> _serviceTradeCategory;
        private Mock<IMapper> _mappermock;

        [SetUp]
        public void setup()
        {
            _fixture = new Fixture();
            _serviceTradeCategory = new Mock<IServiceTradeCategory>();
            _mappermock = new Mock<IMapper>();
        }

        [Test]
        public void ApplicationServiceTradeCategory_GetAll_ShouldReturnThreeTradeCategory()
        {
            //arrange
            var tradeCategories = _fixture.Build<TradeCategory>().CreateMany(3);
            var tradeCategoryDto = _fixture.Build<TradeCategoryDto>().CreateMany(3);

            _serviceTradeCategory.Setup(x => x.GetAll()).ReturnsAsync(tradeCategories);
            _mappermock.Setup(x => x.Map<IEnumerable<TradeCategoryDto>>(tradeCategories)).Returns(tradeCategoryDto);

            var applicationServiceTradeCategory = new ApplicationServiceTradeCategory(_serviceTradeCategory.Object, _mappermock.Object);

            //act
            var result = applicationServiceTradeCategory.GetAll();

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result);
            _serviceTradeCategory.VerifyAll();
            _mappermock.VerifyAll();
        }

        [Test]
        public void ApplicationServiceTradeCategory_GetById_ShouldReturnTradeCategory()
        {
            //arrange
            Guid id = Guid.Parse("E86EDF2F-242C-4423-9666-A4DC41EBDD79");

            var tradeCategory = _fixture.Build<TradeCategory>()
                .With(c => c.Id, id)
                .With(c => c.Category, "Public")
                .Create();

            var tradecategorydto = _fixture.Build<TradeCategoryDto>()
                .With(c => c.Id, id)
                .With(c => c.Category, "Public")
                .Create();

            _serviceTradeCategory.Setup(x => x.GetById(id)).ReturnsAsync(tradeCategory);
            _mappermock.Setup(x => x.Map<TradeCategoryDto>(tradeCategory)).Returns(tradecategorydto);

            var applicationServiceTradeCategory =
                new ApplicationServiceTradeCategory(_serviceTradeCategory.Object, _mappermock.Object);

            //act
            var result = applicationServiceTradeCategory.GetById(id);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Public", result.Result.Category);
            Assert.AreEqual(Guid.Parse("E86EDF2F-242C-4423-9666-A4DC41EBDD79"), result.Id);
            _serviceTradeCategory.VerifyAll();
            _mappermock.VerifyAll();
        }
    }
}