﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.FluentMap;

namespace ShippingPlatform.Database
{
    public static class DapperConfiguration
    {
        private static bool isConfigured = false;

        public static void Configure()
        {
            if (isConfigured)
            {
                return;
            }
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new AddressMapper());

            });
        }

    }
}
