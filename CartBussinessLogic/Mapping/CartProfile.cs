using AutoMapper;
using Cart.DataAcces.Entities;
using CartBusinessLogic.Models;

namespace CartBusinessLogic.Mapping
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<ProductModel, Product>();
        }
    }
}
