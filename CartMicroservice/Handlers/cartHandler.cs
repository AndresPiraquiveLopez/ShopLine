﻿using System;
using CartBusinessLogic.Models;
using CartBusinessLogic.UnitOfWork;
using Newtonsoft.Json;
using Unity;

namespace CartMicroservice.Handlers
{
    public class CartHandler : HandlerBase
    {
        private readonly ICartUoW _uoW;

        public CartHandler(IUnityContainer container) : base(container)
        {
            _uoW = container.Resolve<ICartUoW>();
        }



        public int AddItem(string json)
        {
            var products = JsonConvert.DeserializeObject<Product>(json);

            return _uoW.AddItem(products);
        }

        public override void Run()
        {
            throw new NotImplementedException();
        }

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

    }
}
