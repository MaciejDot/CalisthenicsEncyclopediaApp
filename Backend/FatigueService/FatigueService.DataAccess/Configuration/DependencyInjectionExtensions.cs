using CacheManager.Core;
using FatigueService.DataAccess.Cache;
using FatigueService.DataAccess.Hangfire;
using FatigueService.DataAccess.Jobs;
using FatigueService.DataAccess.Repositories;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.Extensions.DependencyInjection;
using SimpleCQRS.DependencyInjectionExtensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace FatigueService.DataAccess.Configuration
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddFatigueServiceDataAccess(this IServiceCollection services, string connectionString)
        {

            services.AddTransient(_ => new SqlConnection(connectionString));
            services.AddTransient<IPopulateFatiguesJob, PopulateFatiguesJob>();
            services.AddSingleton<IBackgroundJobClientService, BackgroundJobClientService>();
            services.AddSingleton<IFatigueCacheService, FatigueCacheService>();
            services.AddSingleton<IFatiguesRepository, FatiguesRepository>();
            services.AddSimpleCQRS(Assembly.GetExecutingAssembly());
            services.AddHangfire(configuration =>
            {
                configuration
                    .UseMemoryStorage();
            });
            services.AddCacheManagerConfiguration(configure =>
                configure
                .WithMicrosoftMemoryCacheHandle()
                .WithExpiration(ExpirationMode.Absolute, TimeSpan.FromMinutes(60)));
            services.AddCacheManager();
            return services;
        }
    }
}
