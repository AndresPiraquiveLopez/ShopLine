using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Cart.DataAcces.Entities;
using CartBusinessLogic.Factories;
using CartBusinessLogic.Models;
using CartBusinessLogic.Repositories;
using CartBusinessLogic.UnitOfWork;

namespace CartBussinessLogic.UnitOfWork
{
    public class CartUoW : BaseUoW, ICartUoW
    {
        private Dictionary<string, string> Session = new Dictionary<string, string>();

        public IRepository<Cart.DataAcces.Entities.Cart> CartRepository => GetRepository<Cart.DataAcces.Entities.Cart>();

        public IRepository<CartItem> CartItemRepository => GetRepository<CartItem>();

        //public IRepository<CartItem> CartAllItemRepository => GetRepository<CartItem>();

        public CartUoW(IRepositoryProvider repositoryProvider) : base(repositoryProvider)
        {
        }

        public int AddItem(CartItemModel newItem)
        {
            var userId = GetUserId();
            var cartId = GetCartId();


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
                Commit();
                return itemBd.ItemId;
            }

            item.CartId = cartId;
            item.Quantity = 1;
            item.DateCreated = DateTime.Now;

            CartItemRepository.Add(item);

            Commit();

            return item.ItemId;
        }


        List<CartItemModel> ICartUoW.GetCartItems()
        {
            var cartId = GetCartId();

            var cartItemsBd = CartItemRepository.GetAll().Where(i => i.CartId == cartId).ToList();

            var cartItemsModel = Mapper.Map<List<CartItemModel>>(cartItemsBd);

            return cartItemsModel;


        }

        public decimal GetTotal()
        {
            throw new System.NotImplementedException();
        }

        public int RemoveItem(CartItemModel item)
        {
            var cartId = GetCartId();

            var itemBd =
                CartItemRepository.GetAll().FirstOrDefault(
                    i => i.CartId == cartId && i.ProductId == item.ProductId
                );

            if (itemBd != null)
            {
                var id = itemBd.ItemId;
                CartItemRepository.Remove(itemBd);
                Commit();
                return id;
            }

            return -1;

        }

        public int UpdateQtyItem(int productId, int qty)
        {
            var cartId = GetCartId();

            var itemBd = CartItemRepository
                            .GetAll()
                            .FirstOrDefault(i => i.CartId == cartId && i.ProductId == productId);

            if (itemBd != null)
            {
                itemBd.Quantity = qty;

                Commit();

                return itemBd.ItemId;
            }

            return -1;
        }

        public int GetNbrItems()
        {
            var cartId = GetCartId();

            return CartItemRepository.GetAll().Count(i => i.CartId == cartId);
        }

        public void EmptyCart()
        {
            throw new System.NotImplementedException();
        }


        public string AddCart(CartModel newCart)
        {
            var cart = Mapper.Map<Cart.DataAcces.Entities.Cart>(newCart);

            CartRepository.Add(cart);

            Commit();

            return cart.CartId;
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
            return Session["CartId"];
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
