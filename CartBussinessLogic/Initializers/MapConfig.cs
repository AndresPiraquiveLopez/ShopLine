using System;
using AutoMapper;
using CartBussinessLogic.Mapping;

namespace CartBusinessLogic.Initializers
{
    public class MapConfig
    {
        public static void RegisterMapping()
        {
            Mapper.Reset();
            Mapper.Initialize(configuration =>
                {
                    configuration.AddProfiles(typeof(CartProfile).Assembly);
                }
            );
        }
    }
}
