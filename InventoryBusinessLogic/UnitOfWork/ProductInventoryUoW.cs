using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Inventory.DataAcces.Entities;
using InventoryBusinessLogic.Factories;
using InventoryBusinessLogic.Models;
using InventoryBusinessLogic.Repositories;

namespace InventoryBusinessLogic.UnitOfWork
{
    public class ProductInventoryUoW : BaseUoW, IProductInventoryUoW
    {
        public IRepository<Product> ProductRepository => GetRepository<Product>();

        public ProductInventoryUoW(IRepositoryProvider repositoryProvider) : base(repositoryProvider)
        {
        }
        
        public IEnumerable<ProductInventoryModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public void AddProduct(ProductModel productModel)
        {
            var productBd = ProductRepository.GetAll().Include("ProductCategory").FirstOrDefault(s => s.Name == productModel.Name && s.Code == productModel.Code);           
          

            if (productBd == null)
            {
                var product = Mapper.Map<Product>(productModel);

                ProductRepository.Add(product);

                Commit();
            }      
        }

        public ProductInventoryModel Reserve(int id)
        {
            throw new NotImplementedException();
        }

        public ProductInventoryModel UnReserve(int id)
        {
            throw new NotImplementedException();
        }

        public void Receive(IEnumerable<ProductInventoryModel> items)
        {
            throw new NotImplementedException();
        }

        public void Order(IEnumerable<ProductInventoryModel> items)
        {
            throw new NotImplementedException();
        }

        public int CheckMinQty(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> GetProduct(string productId)
        {
            throw new NotImplementedException();
        }
    }
}
