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
            var products = JsonConvert.DeserializeObject<ProductInventory>(json);

            return _uoW.AddToStockQty(products);
        }

        public override void Run()
        {
            throw new NotImplementedException();
        }

        public void AdjStock(string json)
        {
            var product = JsonConvert.DeserializeObject<ProductInventory>(json);

            _uoW.AdjStock(product.Qty, product.Id);
        }
    }
}
