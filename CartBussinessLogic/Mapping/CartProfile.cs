using AutoMapper;
using CartDataAcces.Entities;
using CartBusinessLogic.Models;

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
