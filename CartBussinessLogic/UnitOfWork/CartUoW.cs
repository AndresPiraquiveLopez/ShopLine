using System.Collections.Generic;
using AutoMapper;
using Cart.DataAcces.Entities;
using CartBusinessLogic.Factories;
using CartBusinessLogic.Models;
using CartBusinessLogic.Repositories;

namespace CartBusinessLogic.UnitOfWork
{
    public class CartUoW : BaseUoW, ICartUoW
    {
        public IRepository<Product> ProductRepository => GetRepository<Product>();

        public CartUoW(IRepositoryProvider repositoryProvider) : base(repositoryProvider)
        {
        }

        public void AddItem(ProductModel newProduct)
        {
            var product = Mapper.Map<Product>(newProduct);

            ProductRepository.Add(product);

            Commit();


        }

        public int GetCartId()
        {
            throw new System.NotImplementedException();
        }

        public decimal GetTotal()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveItem(string cartId, int productId)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateQtyItem(string cartId, int productId, int qty)
        {
            throw new System.NotImplementedException();
        }

        public int GetNbrItems()
        {
            throw new System.NotImplementedException();
        }

        public void EmptyCart()
        {
            throw new System.NotImplementedException();
        }

        List<CartItemModel> ICartUoW.GetCartItems()
        {
            throw new System.NotImplementedException();
        }
    }
}
