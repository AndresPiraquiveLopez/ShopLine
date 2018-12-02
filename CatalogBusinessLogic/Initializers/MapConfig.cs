using AutoMapper;
using CatalogBusinessLogic.Mapping;

namespace CatalogBusinessLogic.Initializers
{
    public class MapConfig
    {
        public static void RegisterMapping()
        {
            Mapper.Reset();
            Mapper.Initialize(configuration =>
                {
                    configuration.AddProfiles(typeof(CatalogProfile).Assembly);
                }
            );
        }
    }
}
