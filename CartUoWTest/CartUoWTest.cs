using System;
using System.Linq;
using AutoFixture;
using Cart.DataAcces.Entities;
using CartBusinessLogic.Models;
using CartBusinessLogic.UnitOfWork;
using CartUoWTest.Mocking;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CartUoWTest
{
    [TestClass]
    public class CartUoWTest
    {
        private static Fixture _fixture;

        private static ICartUoW _sut;

        private static MockRepositoryProvider _mock;


        [TestInitialize]
        public void TestMethod1()
        {
            _fixture = new Fixture { RepeatCount = 1 };
            _mock = new MockRepositoryProvider(_fixture);


            // in most cases only one item is required for tests, do not force to have the 12
            // as set in MockRepositoryProvider
            _fixture.RepeatCount = 1;

            _sut = new CartUoW(_mock);
        }

        [TestMethod]
        public void GetAddToStockQty_MoreThanZero()
        {
            //arange                       
            var product = new ProductModel
            {
                ProductId = 1,
                CategoryId = 1,
                ProductName = "Macbook Pro 2018",
                Description = "Test",
                ImagePath = "http://images-server/Macbook-pro-2018",
                UnitPrice = 1999.99
            };

            var result = _mock.CreateRepository<Product>().GetAll().First();

            //act
            _sut.AddItem(product);

            //assert
            Assert.IsTrue(result.CategoryId == 1);
        }
    }
}
