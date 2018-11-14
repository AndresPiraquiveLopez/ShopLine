using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Inventory.DataAcces.Entities;
using InventoryBusinessLogic.Factories;
using InventoryBusinessLogic.Models;
using InventoryBusinessLogic.Repositories;

namespace InventoryBusinessLogic.UnitOfWork
{
    public class InventoryUoW : BaseUoW, IInventoryUoW
    {
        public InventoryUoW(IRepositoryProvider repositoryProvider) : base(repositoryProvider)
        {
        }

                
        public IRepository<Product> ProductRepository => GetRepository<Product>();

        public void TransfertQty()
        {
            throw new System.NotImplementedException();
        }

        public void AddToStockQty()
        {
            throw new System.NotImplementedException();
        }

        public void Delete()
        {
            throw new System.NotImplementedException();
        }

        public void AdjStock()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ProductInventory> GetAll()
        {
          
                
            var product = ProductRepository.GetAll().ToList();
           
            return null;
        }

        public ProductInventory Reserve(int id)
        {
            throw new System.NotImplementedException();
        }

        public ProductInventory UnReserve(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Receive(IEnumerable<ProductInventory> items)
        {
            throw new System.NotImplementedException();
        }

        public void Order(IEnumerable<ProductInventory> items)
        {
            throw new System.NotImplementedException();
        }

        public int CheckMinQty(int id)
        {
            throw new System.NotImplementedException();
        }

       
    }
}
