using System;
using CatalogBusinessLogic.UnitOfWork;
using Unity;

namespace CatalogBusinessLogic.Handlers
{
    public class CatalogHandler : HandlerBase
    {
        private readonly ICatalogUoW _uoW;

        public CatalogHandler(IUnityContainer container) : base(container)
        {
            _uoW = container.Resolve<ICatalogUoW>();
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
