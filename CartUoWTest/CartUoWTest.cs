using System;
using System.Linq;
using AutoFixture;
using Cart.DataAcces.Entities;
using CartBusinessLogic.Initializers;
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

            MapConfig.RegisterMapping();
            // in most cases only one item is required for tests, do not force to have the 12
            // as set in MockRepositoryProvider
            _fixture.RepeatCount = 1;

            _sut = new CartUoW(_mock);
        }

        [TestMethod]
        public void AddItemTo_Cart()
        {
            ////arange                       
            //var product = new ProductModel
            //{
            //    ProductId = 1,
            //    CategoryId = 1,
            //    ProductName = "Macbook Pro 2018",
            //    Description = "Test",
            //    ImagePath = "http://images-server/Macbook-pro-2018",
            //    UnitPrice = 1999.99
            //};

            //var mock = _mock.CreateRepository<Product>().GetAll().First();
           
            var product = _fixture.Create<ProductModel>();
            //mock.ProductId = product.ProductId;
           //act
           _sut.AddItem(product);

            //assert
            //Assert.AreEqual(mock.UnitPrice, product.UnitPrice);
            Assert.IsTrue(_mock.CommitCallCount > 0);
        }
    }
}
