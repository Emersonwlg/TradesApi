//using System.Collections.Generic;
//using System.Linq;
//using AutoFixture;
//using AutoMapper;
//using Moq;
//using NUnit.Framework;
//using Trades.Application;
//using Trades.Application.Dtos;
//using Trades.Domain.Core.Interfaces.Services;
//using Trades.Domain.Entitys;

//namespace Trades.Tests
//{
//    [TestFixture]
//    public class ApplicationServiceTradeCategoryTest
//    {

//        private static Fixture _fixture;
//        private Mock<IServiceTradeCategory> _serviceTradeCategoryMock;
//        private Mock<IMapper> _mapperMock;


//        [SetUp]
//        public void Setup()
//        {
//            _fixture = new Fixture();
//            _serviceTradeCategoryMock = new Mock<IServiceTradeCategory>();
//            _mapperMock = new Mock<IMapper>();
//        }

//        [Test]
//        public void ApplicationServiceTradeCategoryTestGetTradeCategoriesByTrades_ShouldReturnFiveCTradeCagegories()
//        {
//            //Arrange
//            var clientes = _fixture.Build<Cliente>().CreateMany(5);
//            var clientesDto = _fixture.Build<ClienteDto>().CreateMany(5);

//            _serviceTradeCategoryMock.Setup(x => x.GetAll()).Returns(clientes);
//            _mapperMock.Setup(x => x.Map<IEnumerable<ClienteDto>>(clientes)).Returns(clientesDto);

//            var applicationServiceCliente = new ApplicationServiceCliente(_serviceTradeCategoryMock.Object, _mapperMock.Object);

//            //Act
//            var result = applicationServiceCliente.GetAll();

//            //Assert
//            Assert.IsNotNull(result);
//            Assert.AreEqual(5, result.Count());
//            _serviceTradeCategoryMock.VerifyAll();
//            _mapperMock.VerifyAll();
//        }

//        [Test]
//        public void ApplicationServiceTradeCategoryTest_GetById_ShouldReturnTradeCategory()
//        {
//            //Arrange
//            const int id = 10;

//            var cliente = _fixture.Build<TradeCategory>()
//                .With(c => c.Id, id)
//                .With(c => c.Email, "teste1@teste.com.br")
//                .Create();

//            var tradeCategoryDto = _fixture.Build<TradeCategoryDto>()
//                .With(c => c.Id, id)
//                .With(c => c.Email, "teste1@teste.com.br")
//                .Create();

//            _serviceTradeCategoryMock.Setup(x => x.GetById(id)).Returns(cliente);
//            _mapperMock.Setup(x => x.Map<ClienteDto>(cliente)).Returns(clienteDto);

//            var applicationServiceCliente =
//                new ApplicationServiceCliente(_serviceTradeCategoryMock.Object, _mapperMock.Object);

//            //Act
//            var result = applicationServiceCliente.GetById(id);

//            //Assert
//            Assert.IsNotNull(result);
//            Assert.AreEqual("teste1@teste.com.br", result.Email);
//            Assert.AreEqual(10, result.Id);
//            _serviceTradeCategoryMock.VerifyAll();
//            _mapperMock.VerifyAll();


//        }

//    }
//}