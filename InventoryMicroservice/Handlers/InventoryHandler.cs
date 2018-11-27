using System;
using InventoryBusinessLogic.Models;
using InventoryBusinessLogic.UnitOfWork;
using Newtonsoft.Json;
using Unity;

namespace InventoryMicroservice.Handlers
{
    public class InventoryHandler : HandlerBase
    {
        private readonly IInventoryUoW _uoW;

        public InventoryHandler(IUnityContainer container) : base(container)
        {
            _uoW = container.Resolve<IInventoryUoW>();
        }

        

        public int Add(string json)
        {
            var product = JsonConvert.DeserializeObject<ProductInventoryModel>(json);

            return _uoW.AddToStock(product.Qty, product.ProductId);
        }

        public override void Run()
        {
            throw new NotImplementedException();
        }

        public void AdjStock(string json)
        {
            var stock = JsonConvert.DeserializeObject<StockModel>(json);

            _uoW.AdjStock(stock.StockId, stock.Qty, stock.ProductId);
        }

        public void TransfertQty(string json)
        {
            var productInventory = JsonConvert.DeserializeObject<ProductInventoryModel>(json);
        
            _uoW.TransfertQty(productInventory.Qty, productInventory.From, productInventory.To);
        }

        public void Delete(string json)
        {
            var product = JsonConvert.DeserializeObject<ProductInventoryModel>(json);

            _uoW.RemoveFrom(product.Id);
        }
    }
}
