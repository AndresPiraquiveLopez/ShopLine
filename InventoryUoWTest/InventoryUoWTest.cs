using System.Linq;
using AutoFixture;
using Inventory.DataAcces.Entities;
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
            _fixture = new Fixture { RepeatCount = 1 };
            _mock = new MockRepositoryProvider(_fixture);


            // in most cases only one item is required for tests, do not force to have the 12
            // as set in MockRepositoryProvider
            _fixture.RepeatCount = 1;

            _sut = new InventoryUoW(_mock);
        }

        [TestMethod]
        public void GetAddToStockQty_MoreThanZero()
        {
            //arange                       
            var stock = new StockModel
            {
                StockId = 1,
                ProductId = 1,
                Qty = 10
            };

            _mock.CreateRepository<Stock>().GetAll().First();

            //act
            var result = _sut.AddToStock(stock.Qty, stock.ProductId);

            //assert
            Assert.IsTrue(result == 1);
        }

    }
}
