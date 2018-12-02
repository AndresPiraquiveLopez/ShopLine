using AutoMapper;
using Catalog.DataAcces.Entities;
using CatalogBusinessLogic.Models;

namespace CatalogBusinessLogic.Mapping
{
    public class CatalogProfile : Profile
    {
        public CatalogProfile()
        {
            CreateMap<ProductModel, Product>();
        }
    }
}
