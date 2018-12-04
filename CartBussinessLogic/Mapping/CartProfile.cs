using AutoMapper;
using CartBusinessLogic.Models;
using System.Collections.Generic;
using Cart.DataAcces.Entities;

namespace CartBusinessLogic.Mapping
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<ProductModel, Product>();
            CreateMap<CartItemModel, CartItem>();
            CreateMap<CartItem, CartItemModel>();
        }
    }
}
