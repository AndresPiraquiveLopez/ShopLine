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

        public IRepository<ProductInventory> ProductInventoryRepository => GetRepository<ProductInventory>();

        public ProductInventoryUoW(IRepositoryProvider repositoryProvider) : base(repositoryProvider)
        {
        }
        
        public IEnumerable<ProductInventoryModel> GetAllInventory()
        {
            var productInventory = ProductInventoryRepository.GetAll().Include("Location").ToList();

            var model = Mapper.Map<IEnumerable<ProductInventoryModel>>(productInventory);


            return model;
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

        public ProductModel GetProduct(string productName, string code)
        {
            var product = ProductRepository.GetAll().FirstOrDefault(p => p.Name == productName && p.Code == code);

            return Mapper.Map<ProductModel>(product);
        }

        public void RemoveFrom(int id)
        {
            var product = ProductRepository.GetAll().FirstOrDefault(p => p.ProductId == id);

            ProductRepository.Remove(product);
            Commit();
        }
    }
}
