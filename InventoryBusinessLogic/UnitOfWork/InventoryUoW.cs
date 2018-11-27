using System.Collections;
using System.Collections.Generic;
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


        public void TransfertQty(int qty, string from, string to)
        {
            throw new System.NotImplementedException();
        }       

        public int AddToStock(int qty, int id)
        {           
            var stock = new Stock
            {
                StockId = 0,                
                ProductId = id,
                Qty = qty
            };

            StockRepository.Add(stock);

            Commit();

            return stock.ProductId;
        }

        public void RemoveFrom(int id)
        {
            var product = ProductRepository.GetAll().FirstOrDefault(p => p.ProductId == id);

            ProductRepository.Remove(product);
            Commit();
        }

        public void AdjStock(int stockId, int qty, int id)
        {           
            var stock = StockRepository.GetAll().FirstOrDefault(i => i.ProductId == id && i.StockId == stockId);

            if (stock != null) stock.Qty = qty;
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
