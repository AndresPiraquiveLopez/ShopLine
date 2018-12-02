using System.Collections.Generic;
using AutoMapper;
using Catalog.DataAcces.Entities;
using CatalogBusinessLogic.Factories;
using CatalogBusinessLogic.Models;
using CatalogBusinessLogic.Repositories;

namespace CatalogBusinessLogic.UnitOfWork
{
    public class CatalogUoW : BaseUoW, ICatalogUoW
    {
        public IRepository<Product> ProductRepository => GetRepository<Product>();

        public CatalogUoW(IRepositoryProvider repositoryProvider) : base(repositoryProvider)
        {
        }

        public IList<CategoryModel> Catalog(int id)
        {
           return new List<CategoryModel>() {
               new CategoryModel
               {
                   CatalogId = 1,
                   CategoryName ="Ordinateur & tablette",
                   Id = 1                   
               }
           };
        }

        public int AddProduct(ProductModel newProduct)
        {
            var product = Mapper.Map<Product>(newProduct);

            ProductRepository.Add(product);

            Commit();

            return product.Id;
        }


        //get product list
        public IList<ProductModel> Category(int id)
        {
            return new List<ProductModel>() {
               new ProductModel
               {
                   CategoryId = 1,
                   Id = 1, ProductName ="HP ProBook x360 11 G1 laptop"
               }
           };
        }


        //get product details
        public IList<ProductModel> Product(int id)
        {
            return new List<ProductModel>() {
               new ProductModel
               {
                   ProductName ="HP ProBook x360 11 G1 laptop, Dual-Core N3350 2.4GHz | 128GB SSD | 4GB RAM |W10",
                   Id = 1
               }
           };
        }
    }
}
