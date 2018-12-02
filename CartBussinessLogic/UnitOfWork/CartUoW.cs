using System;
using System.Collections.Generic;
using AutoMapper;
using CartDataAcces.Entities;
using CartBusinessLogic.Factories;
using CartBusinessLogic.Models;
using CartBusinessLogic.Repositories;
using System.Linq;

namespace CartBusinessLogic.UnitOfWork
{
    public class CartUoW : BaseUoW, ICartUoW
    {
        private Dictionary<string, string> Session = new Dictionary<string, string>();

        public IRepository<Cart> CartRepository => GetRepository<Cart>();

        public IRepository<CartItem> CartItemRepository => GetRepository<CartItem>();

        public CartUoW(IRepositoryProvider repositoryProvider) : base(repositoryProvider)
        {
        }

        public int AddItem(CartItemModel newItem)
        {
            var userId = GetUserId();
            var cartId = GetCartId();
            var itemId = newItem.ItemId;

            var item = Mapper.Map<CartItem>(newItem);

            if (IsNewCart(cartId))
                CreateNewCart(cartId, userId);


            var itemBd =
                CartItemRepository.GetAll().FirstOrDefault(
                    i => i.CartId == cartId && i.ProductId == item.ProductId
                );

            if (itemBd != null)
            {
                itemBd.Quantity++;
            }
            else
            {
                item.CartId = cartId;
                item.Quantity = 1;
                item.DateCreated = DateTime.Now;

                CartItemRepository.Add(item);
            }

            Commit();

            return item.ItemId;
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

        public string AddCart(CartModel newCart)
        {
            var cart = Mapper.Map<Cart>(newCart);

            CartRepository.Add(cart);

            Commit();

            return cart.CartId;
        }

        public void AddItem(ProductModel newProduct)
        {
            throw new NotImplementedException();
        }

        private bool IsNewCart(string cartId)
        {
            return CartRepository.GetAll().FirstOrDefault(c => c.CartId == cartId) == null;
        }

        //private bool IsNewItem(string cartId, int itemId)
        //{
        //    return == null;
        //}




        private string CreateNewCart(string id, string userId)
        {
            CartModel newCart = new CartModel
            {
                CartId = id,
                UserId = userId,
                DateCreated = DateTime.Now
            };

            return AddCart(newCart);
        }

        private string GetCartId()
        {
            if (!Session.ContainsKey("CartId"))
            {
                // Generate a new random GUID using System.Guid class.     
                // Guid cartId = Guid.NewGuid();
                // Session.Add("CartId", cartId.ToString());
                Session.Add("CartId", "68fad8e0-7818-41d9-8dde-71139fcdbe87");
            }
            return Session["UserId"];
        }
    
      
        private string GetUserId()
        {
            if (!Session.ContainsKey("UserId"))
            {
                // Generate a new random GUID using System.Guid class.     
                //Guid userId = Guid.NewGuid();
                //Session.Add("UserId", userId.ToString());
                Session.Add("UserId", "9276bd0d-251b-46aa-b485-abbe6e7834eb");
            }
            return Session["UserId"];
        }

        public void RemoveItem(int itemId)
        {
            throw new NotImplementedException();
        }
    }
}
