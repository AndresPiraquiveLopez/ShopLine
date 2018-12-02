using System;
using AutoMapper;
using InventoryBusinessLogic.Mapping;

namespace InventoryBusinessLogic.Initializers
{
    public static class MapConfig
    {
        public static void RegisterMapping()
        {
            Mapper.Reset();
            Mapper.Initialize(configuration =>
                {
                    configuration.AddProfiles(typeof(InventoryProfile).Assembly);
                }
            );
        }
    }
}
