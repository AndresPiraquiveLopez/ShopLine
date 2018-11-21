using AutoMapper;
using CatalogBusinessLogic.Models;
using InventoryBusinessLogic.Models;

namespace CatalogBusinessLogic.Mapping
{
    public class InventoryProfile : Profile
    {
        public InventoryProfile()
        {
            CreateMap<ProductInventory, Class1>();
        }
    }
}
