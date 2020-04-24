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

            //sut (System under test)
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
        public void AddProduct_CallCommit_With_Autofixture()
        {
            //arange                                   
            var newProduct = _fixture.Create<ProductModel>();
                  
            //act
             _sut.AddProduct(newProduct);

            //assert
            Assert.IsTrue(_mock.CommitCallCount > 0);
        }

        [TestMethod]
        public void AddProduct_CallCommit_WithoutAutofixture()
        {
            //arange
            var newProduct = new ProductModel
            {
                Id = 1,
                Code = "CAD",
                Cost = 10,
                Name = "Billet Metro",
                ProductCategoryId = 1,
                ProductCategory = new ProductCategoryModel
                {
                    Id = 1,
                    Category = "Test",                    
                },
                SellPrice = 10
            };          

            //act
           _sut.AddProduct(newProduct);

            //assert
            Assert.IsTrue(_mock.CommitCallCount > 0);

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
