using AutoMapper;
using TrocoBrq.Cross.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrocoBrq.Aplication.AutoMapper
{
    public static class ConfigureMap
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<DataMappingProfile>();
                cfg.AddProfile<WebMappingProfile>();
            });
        }
    }
}
