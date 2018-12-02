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
        void TransfertQtyStock(TransfertStockModel transfertStockMode);

        int AddToStock(StockModel stock);     

        void RemoveFromStock(string name);

        void AdjStock(StockModel stock);      
    }
}
