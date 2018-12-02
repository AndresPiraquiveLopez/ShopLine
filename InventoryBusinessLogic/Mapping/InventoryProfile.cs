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
            CreateMap<StockModel, Stock>();
            CreateMap<Stock, StockModel>();
            CreateMap<ProductModel, Product>();
        }
    }
}
