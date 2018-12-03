using AutoMapper;
using Inventory.DataAcces.Entities;
using InventoryBusinessLogic.Models;

namespace InventoryBusinessLogic.Mapping
{
    public class InventoryProfile : Profile
    {
        public InventoryProfile()
        {
            CreateMap<ProductInventoryModel, Product>();

            CreateMap<ProductInventory, ProductInventoryModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Available, opt => opt.Ignore())
                .ForMember(dest => dest.From, opt => opt.Ignore())
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.OnOrder, opt => opt.Ignore())
                .ForMember(dest => dest.Qty, opt => opt.MapFrom(src => src.Count))
                .ForMember(dest => dest.Reserved, opt => opt.Ignore())
                .ForMember(dest => dest.To, opt => opt.Ignore());

            CreateMap<Location, LocationModel>()
                .ForMember(dest => dest.LocationId, opt => opt.MapFrom(src => src.LocationId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<LocationModel, Location>();

            CreateMap<StockModel, Stock>();

            CreateMap<Stock, StockModel>();

            CreateMap<Product, ProductModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))                
                .ForMember(dest => dest.ProductCategory, opt => opt.MapFrom(src => src.ProductCategory))                
                .ForMember(dest => dest.ProductCategoryId, opt => opt.MapFrom(src => src.ProductCategoryId))
                .ForMember(dest => dest.Cost, opt => opt.MapFrom(src => src.Cost))
                .ForMember(dest => dest.SellPrice, opt => opt.MapFrom(src => src.SellPrice));

            CreateMap<ProductModel, Product>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))                
                .ForMember(dest => dest.ProductCategory, opt => opt.MapFrom(src => src.ProductCategory))
                .ForMember(dest => dest.ProductCategoryId, opt => opt.MapFrom(src => src.ProductCategoryId))
                .ForMember(dest => dest.Cost, opt => opt.MapFrom(src => src.Cost))
                .ForMember(dest => dest.SellPrice, opt => opt.MapFrom(src => src.SellPrice));

            CreateMap<ProductCategoryModel, ProductCategory>()
                .ForMember(dest => dest.ProductCategoryId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));

            CreateMap<ProductCategory, ProductCategoryModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductCategoryId))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));
        }
    }
}
