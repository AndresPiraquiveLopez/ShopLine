using System;
using System.Linq;
using AutoFixture;
using Inventory.DataAcces.Entities;
using InventoryBusinessLogic.Models;
using InventoryBusinessLogic.UnitOfWork;
using InventoryUoWTest.Mocking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

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
            var product = new ProductInventory
            {
                Id = 1,
                Code = "AAA",
                CategoryId = 1,
                Cost = 10,
                SellPrice = 5,
                Name = "TOTO",
                Qty = 1
            };

           _mock.CreateRepository<Product>().GetAll().First();            

            //act
            var result = _sut.AddToStockQty(product);

            //assert
            Assert.IsTrue(result > 0);            
        }

    }
}
