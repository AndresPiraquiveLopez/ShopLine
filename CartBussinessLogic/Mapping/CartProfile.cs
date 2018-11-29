using AutoMapper;
using Cart.DataAcces.Entities;
using CartBusinessLogic.Models;

namespace CartBussinessLogic.Mapping
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
