using System;
using Newtonsoft.Json;
using Unity;

namespace CartMicroservice.Handlers
{
    public class CartHandler : HandlerBase
    {
        //private readonly ICartUoW _uoW;

        public CartHandler(IUnityContainer container) : base(container)
        {
            //_uoW = container.Resolve<ICartUoW>();
        }

        

        //public int Add(string json)
        //{
        //    var products = JsonConvert.DeserializeObject<ProductInventory>(json);

        //    return _uoW.AddToStockQty(products);
        //}

        //public override void Run()
        //{
        //    throw new NotImplementedException();
        //}

        //public void AdjStock(string json)
        //{
        //    var product = JsonConvert.DeserializeObject<ProductInventory>(json);

        //    _uoW.AdjStock(product.Qty, product.Id);
        //}

        //public void TransfertQty(string json)
        //{
        //    var product = JsonConvert.DeserializeObject<ProductInventory>(json);

        //    _uoW.TransfertQty(product.Qty, product.Id);
        //}

        //public void Delete(string json)
        //{
        //    var product = JsonConvert.DeserializeObject<ProductInventory>(json);

        //    _uoW.Delete(product.Id);
        //}
        public override void Run()
        {
            throw new NotImplementedException();
        }
    }
}
