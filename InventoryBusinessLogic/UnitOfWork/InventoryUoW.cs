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
        public IRepository<Product> ProductRepository => GetRepository<Product>();

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

        public void RemoveFrom(int id)
        {
            var product = ProductRepository.GetAll().FirstOrDefault(p => p.ProductId == id);

            ProductRepository.Remove(product);
            Commit();
        }

        public void AdjStock(StockModel stiockModel)
        {           
            var stock = StockRepository.GetAll().FirstOrDefault(s => s.ProductId == stiockModel.ProductId 
                                                                && s.StockId == stiockModel.StockId);

            if (stock != null) stock.Qty = stiockModel.Qty;

            Commit();

        }

        //public IEnumerable<ProductInventory> GetAll()
        //{
        //    var product = ProductRepository.GetAll().ToList();

        //    return null;
        //}

        //public ProductInventory Reserve(int id)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public ProductInventory UnReserve(int id)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public void Receive(IEnumerable<ProductInventory> items)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public void Order(IEnumerable<ProductInventory> items)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public int CheckMinQty(int id)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public int AddToStockQty()
        //{
        //    var product = new Product
        //    {
        //        Id = 3,
        //        CategoryId = 1,
        //        Code = "AAA",
        //        Name = "Subaru",
        //        SellPrice = 15,
        //        Cost = 15
        //    };
        //    ProductRepository.Add(product);
        //    Commit();
            
        //    return product.Id;
        //}
    }
}
