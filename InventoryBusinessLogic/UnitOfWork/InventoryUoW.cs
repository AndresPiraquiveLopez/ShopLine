using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Inventory.DataAcces.Entities;
using InventoryBusinessLogic.Factories;
using InventoryBusinessLogic.Models;
using InventoryBusinessLogic.Repositories;

namespace InventoryBusinessLogic.UnitOfWork
{
    public class InventoryUoW : BaseUoW, IInventoryUoW
    {
        public IRepository<Stock>StockRepository => GetRepository<Stock>();

        public InventoryUoW(IRepositoryProvider repositoryProvider) : base(repositoryProvider)
        {
        }


        public void TransfertQtyStock(TransfertStockModel transfertStockModel)
        {
            var fromStock = StockRepository.GetAll().Include("Product").FirstOrDefault(s => s.ProductId == transfertStockModel.ProductId && s.StockId == transfertStockModel.FromStockId);

            if (fromStock?.ProductId == null) return;
            {
                var toStock = StockRepository.GetAll().FirstOrDefault(s => s.StockId == transfertStockModel.ToStockId 
                                                                           && s.ProductId == transfertStockModel.ProductId);

                if (toStock != null)
                {
                    toStock.Qty = transfertStockModel.Qty + toStock.Qty;
                    fromStock.Qty = fromStock.Qty - transfertStockModel.Qty;
                }

                Commit();
            }

            //Return message to say the productId is null or the product does not exist
        }       

        public int AddToStock(StockModel stockModel)
        {            
            var stockBd = StockRepository.GetAll().FirstOrDefault(s => s.StockId == stockModel.StockId);
            var stock = Mapper.Map<Stock>(stockModel);

            if (stockBd != null)
            {
                stockBd.Qty = stockBd.Qty + stockModel.Qty;
            }
            else
            {                
                StockRepository.Add(stock);
            }
          
            Commit();
            return stockModel.ProductId;
        }
      
        public void RemoveFromStock(string name)
        {
            var stock = StockRepository.GetAll().FirstOrDefault(s => s.Name == name);

            if (stock != null)
            {
                StockRepository.Remove(stock);
                Commit();
            }
         
        }

       

        public void AdjStock(StockModel stiockModel)
        {           
            var stock = StockRepository.GetAll().FirstOrDefault(s => s.ProductId == stiockModel.ProductId 
                                                                && s.StockId == stiockModel.StockId);

            if (stock != null) stock.Qty = stiockModel.Qty;

            Commit();

        }
    }
}
