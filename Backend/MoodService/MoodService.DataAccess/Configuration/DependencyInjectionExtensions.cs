using CacheManager.Core;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.Extensions.DependencyInjection;
using MoodService.DataAccess.Cache;
using MoodService.DataAccess.Hangfire;
using MoodService.DataAccess.Jobs;
using MoodService.DataAccess.Repositories;
using SimpleCQRS.DependencyInjectionExtensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace MoodService.DataAccess.Configuration
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddMoodServiceDataAccess(this IServiceCollection services, string connectionString)
        {
            services.AddSimpleCQRS(Assembly.GetExecutingAssembly());
            services.AddTransient(_ => new SqlConnection(connectionString));
            services.AddSingleton<IMoodCacheService, MoodCacheService>();
            services.AddSingleton<IMoodRepository, MoodRepository>();
            services.AddSingleton<IBackgroundJobClientService, BackgroundJobClientService>();
            services.AddTransient<IPopulateMoodCacheJob, PopulateMoodCacheJob>();
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
