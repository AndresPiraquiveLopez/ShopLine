using System;
using AutoMapper;
using InventoryBusinessLogic.Mapping;

namespace InventoryBusinessLogic.Initializers
{
    public class MapConfig
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
