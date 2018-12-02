using System.Linq;
using AutoFixture;
using Inventory.DataAcces.Entities;
using InventoryBusinessLogic.Initializers;
using InventoryBusinessLogic.Models;
using InventoryBusinessLogic.UnitOfWork;
using InventoryUoWTest.Mocking;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InventoryUoWTest
{
    [TestClass]
    public class InventoryUoWTest
    {

        private static Fixture _fixture;

        private static IInventoryUoW _sut;

        private static MockRepositoryProvider _mock;

        [TestInitialize]
        public void TestMethod1()
        {
            _fixture = new Fixture { RepeatCount = 2 };
            _mock = new MockRepositoryProvider(_fixture);
            MapConfig.RegisterMapping();

            _sut = new InventoryUoW(_mock);
        }

        [TestMethod]
        public void AddToStock_New()
        {
            //arange                                   
            var stock = _fixture.Create<StockModel>();

            _mock.CreateRepository<Stock>().GetAll().First();

            //act
            var productId = _sut.AddToStock(stock);

            //assert
            Assert.AreEqual(productId, stock.ProductId);
        }

        [TestMethod]
        public void AddToStock_Qty_In_Exist_Stock()
        {           
            var stockModel = _fixture.Create<StockModel>();

            var mockRepository = _mock.CreateRepository<Stock>().GetAll().First();
            mockRepository.StockId = stockModel.StockId;
            mockRepository.ProductId = stockModel.ProductId;

            //act
            var productId = _sut.AddToStock(stockModel);

            //assert
            Assert.AreEqual(productId, stockModel.ProductId);
        }

        [TestMethod]
        public void RemoveFromStock()
        {           

            var stock = _fixture.Create<StockModel>();

            var stockMock = _mock.CreateRepository<Stock>().GetAll();
            stockMock.First().Name = stock.Name;

            //act
            _sut.RemoveFromStock(stock.Name);

            //assert
            Assert.IsTrue(_mock.CommitCallCount > 0);
        }


        [TestMethod]
        public void TransfertQtyStock_NonCallCommit()
        {          

            var transfertStockModel = _fixture.Create<TransfertStockModel>();

            var stockMock = _mock.CreateRepository<Stock>().GetAll();
            stockMock.First().StockId = transfertStockModel.FromStockId;
            stockMock.Last().StockId = transfertStockModel.ToStockId;

            //act
            _sut.TransfertQtyStock(transfertStockModel);

            //assert
            Assert.IsTrue(_mock.CommitCallCount == 0);
        }

        [TestMethod]
        public void TransfertQtyStock_CallCommit()
        {

            var transfertStockModel = _fixture.Create<TransfertStockModel>();

            var stockMock = _mock.CreateRepository<Stock>().GetAll();

            stockMock.First().StockId = transfertStockModel.FromStockId;
            stockMock.First().ProductId = transfertStockModel.ProductId;

            stockMock.Last().StockId = transfertStockModel.ToStockId;
            stockMock.Last().ProductId = transfertStockModel.ProductId;

            //act
            _sut.TransfertQtyStock(transfertStockModel);

            //assert
            Assert.IsTrue(_mock.CommitCallCount > 0);
        }

        [TestMethod]
        public void AdjStock_CallCommit()
        {

            var stockModel = _fixture.Create<StockModel>();

            var stockMock = _mock.CreateRepository<Stock>().GetAll();

            stockMock.First().StockId = stockModel.StockId;
            stockMock.First().ProductId = stockModel.ProductId;

            //act
            _sut.AdjStock(stockModel);

            //assert
            Assert.IsTrue(_mock.CommitCallCount > 0);
        }

    }
}
