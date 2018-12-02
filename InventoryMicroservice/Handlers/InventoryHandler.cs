using System;
using System.Collections.Generic;
using InventoryBusinessLogic.Models;
using InventoryBusinessLogic.UnitOfWork;
using Newtonsoft.Json;
using Unity;

namespace InventoryMicroservice.Handlers
{
    public class InventoryHandler : HandlerBase
    {
        private readonly IInventoryUoW _inventoryUoW;

        private readonly IProductInventoryUoW _productInventoryUoW;

        public InventoryHandler(IUnityContainer container) : base(container)
        {
            _inventoryUoW = container.Resolve<IInventoryUoW>();

            _productInventoryUoW = container.Resolve<IProductInventoryUoW>();
        }


        public int AddToStock(string json)
        {
            var stock = JsonConvert.DeserializeObject<StockModel>(json);

            return _inventoryUoW.AddToStock(stock);
        }

        public void AdjStock(string json)
        {
            var stock = JsonConvert.DeserializeObject<StockModel>(json);

            _inventoryUoW.AdjStock(stock);
        }

        public void TransfertQtyStock(string json)
        {
            var transfertStock = JsonConvert.DeserializeObject<TransfertStockModel>(json);

            _inventoryUoW.TransfertQtyStock(transfertStock);
        }

        public void RemoveFromStock(string json)
        {
            var stockModel = JsonConvert.DeserializeObject<StockModel>(json);

            _inventoryUoW.RemoveFromStock(stockModel.Name);
        }

        public void AddProduct(string json)
        {
            var product = JsonConvert.DeserializeObject<ProductModel>(json);

            _productInventoryUoW.AddProduct(product);
        }


        public override void Run()
        {
            throw new NotImplementedException();
        }

        public ProductModel GetProduct(string json)
        {
            var product = JsonConvert.DeserializeObject<ProductModel>(json);

            return _productInventoryUoW.GetProduct(product.Name,product.Code);
        }

        public IEnumerable<ProductInventoryModel> GetAllInventory()
        {            

            return _productInventoryUoW.GetAllInventory();
        }
    }
}
