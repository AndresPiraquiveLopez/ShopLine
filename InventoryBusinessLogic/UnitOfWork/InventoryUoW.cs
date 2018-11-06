using System.Collections;
using System.Collections.Generic;
using InventoryBusinessLogic.Models;

namespace InventoryBusinessLogic.UnitOfWork
{
    public class Inventory : IInventoryUoW
    {
        public void Transfert()
        {
            
        }

        public void AddToStockQty()
        {
            
        }

        public void Delete()
        {
            
        }

        public void AdjStock()
        {
            
        }

        public IEnumerable<ProductInventory> GetAll()
        {
            return new List<ProductInventory>();
        }

        public ProductInventory Reserve(int id)
        {
            return new ProductInventory();
        }

        public ProductInventory UnReserve(int id)
        {
            return new ProductInventory();
        }
    
        public void Receive(IEnumerable<ProductInventory> items)
        {
            
        }

        public void Order(IEnumerable<ProductInventory> items)
        {

        }

        public int CheckMinQty(int id)
        {
            return id;
        }
    }
}
