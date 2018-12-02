using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class ProductInventoryUoWTest
    {

        private static Fixture _fixture;

        private static IProductInventoryUoW _sut;

        private static MockRepositoryProvider _mock;

        [TestInitialize]
        public void TestMethod1()
        {
            _fixture = new Fixture { RepeatCount = 2 };
            _mock = new MockRepositoryProvider(_fixture);
            MapConfig.RegisterMapping();

            _sut = new ProductInventoryUoW(_mock);
        }

        [TestMethod]
        public void AddProduct_New()
        {
            //arange                                   
            var product = _fixture.Create<ProductModel>();

            _mock.CreateRepository<Product>().GetAll().First();

            //act
            _sut.AddProduct(product);

            //assert
            Assert.IsTrue(_mock.CommitCallCount > 0);
        }

        [TestMethod]
        public void GetProduct()
        {
            //arange                                   
            var productModel = _fixture.Create<ProductModel>();

           var product = _mock.CreateRepository<Product>().GetAll().First();
            product.Name = productModel.Name;
            product.Code = productModel.Code;
            product.ProductId = productModel.Id;           

           var productCategory = _mock.CreateRepository<ProductCategory>().GetAll().First();
            productCategory.ProductCategoryId = product.ProductCategoryId;

            //act
            var result = _sut.GetProduct(productModel.Name, productModel.Code);

            //assert
            Assert.AreEqual(result.Name, productModel.Name);
            Assert.AreEqual(result.Code, productModel.Code);          
        }


        [TestMethod]
        public void RemoveFrom_CallCommit()
        {
            //arange                                   
            var product = _fixture.Create<ProductModel>();

            _mock.CreateRepository<Product>().GetAll().First();

            //act
            _sut.RemoveFrom(product.Id);

            //assert
            Assert.IsTrue(_mock.CommitCallCount > 0);
        }

        [TestMethod]
        public void GetAllInventory_RespectMapping()
        {
            //arange                                              
            _mock.CreateRepository<ProductInventory>().GetAll().First();
            //act
            var result = _sut.GetAllInventory();

            //assert
            Assert.IsTrue(result.Any());
        }
    }
}
