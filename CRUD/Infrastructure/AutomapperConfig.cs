using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Infrastructure
{
    public class AutomapperConfig
    {
        private static IMapper _instance;
        public static IMapper Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = Create();
                }
                return _instance;
            }
        }

        private static IMapper Create()
        {
            var profileTypes = typeof(AutomapperConfig).Assembly.GetTypes().Where(t => typeof(Profile).IsAssignableFrom(t));

            var configuration = new MapperConfiguration(cfg =>
            {
                foreach (var type in profileTypes)
                {
                    var profile = Activator.CreateInstance(type) as Profile;

                    if(profile == null)
                    {
                        continue;
                    }

                    cfg.AddProfile(profile);
                }
            });

            return configuration.CreateMapper();
        }
    }
}