using System;
using CatalogBusinessLogic.UnitOfWork;
using Newtonsoft.Json;
using Unity;
using CatalogBusinessLogic.Models;
using System.Collections.Generic;

namespace CatalogMicroservice.Handlers
{
    public class CatalogHandler : HandlerBase
    {
        private readonly ICatalogUoW _uoW;

        public CatalogHandler(IUnityContainer container) : base(container)
        {
            _uoW = container.Resolve<ICatalogUoW>();
        }

        public IList<CategoryModel> Catalog(string json)
        {
            var catalogId = JsonConvert.DeserializeObject<CatalogModel>(json);

            return _uoW.Catalog(catalogId.Id);
        }

        //get product list
        public IList<ProductModel> Category(string json)
        {
            var categoryId = JsonConvert.DeserializeObject<CategoryModel>(json);

            return _uoW.Category(categoryId.Id);
        }

        //get product details
        public IList<ProductModel> products(string json)
        {
            var productId = JsonConvert.DeserializeObject<ProductModel>(json);

            return _uoW.Product(productId.Id);
        }

        public override void Run()
        {
            throw new NotImplementedException();
        }
    }
}
