using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryBusinessLogic.Models;

namespace InventoryBusinessLogic.UnitOfWork
{
    public interface IInventoryUoW
    {
        void TransfertQty(int qty, int id);

        int AddToStockQty(ProductInventory products);

        void Delete(int id);
        
        void AdjStock(int qty, int id);

        IEnumerable<ProductInventory> GetAll();

        ProductInventory Reserve(int id);

        ProductInventory UnReserve(int id);

        void Receive(IEnumerable<ProductInventory> items);

        void Order(IEnumerable<ProductInventory> items);

        int CheckMinQty(int id);
        
    }
}
