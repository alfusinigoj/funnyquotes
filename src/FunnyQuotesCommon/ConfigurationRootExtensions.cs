﻿using System;
using System.Collections.Generic;
using System.Timers;
using Microsoft.Extensions.Configuration;
// ReSharper disable CollectionNeverQueried.Local

namespace FunnyQuotesCommon
{
    public static class ConfigurationRootExtensions
    {
        private static readonly List<Timer> Timers = new List<Timer>();

        public static IConfigurationRoot AutoRefresh(this IConfigurationRoot config, TimeSpan timeSpan)
        {
            var myTimer = new Timer();
            myTimer.Elapsed += (sender, args) => config.Reload();
            myTimer.Interval = 10000;
            myTimer.Enabled = true;
            Timers.Add(myTimer);
            return config;
        }
    }

}