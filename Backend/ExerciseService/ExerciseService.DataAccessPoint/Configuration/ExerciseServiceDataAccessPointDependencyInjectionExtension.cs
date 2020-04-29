using CacheManager.Core;
using ExerciseService.DataAccessPoint.Cache;
using ExerciseService.DataAccessPoint.Database;
using ExerciseService.DataAccessPoint.Hangfire;
using ExerciseService.DataAccessPoint.Jobs;
using ExerciseService.DataAccessPoint.Repositories;
using ExerciseService.DataAccessPoint.RepositoriesImplementation;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ExerciseService.DataAccessPoint.Configuration
{
    public static class ExerciseServiceDataAccessPointDependencyInjectionExtension
    {
        public static IServiceCollection AddExerciseServiceDataAccessPoint(this IServiceCollection services, string sqlConnectionString)
        {
            services.AddScoped<IExerciseRepository, ExerciseRepository>();
            services.AddScoped<IUpdateExercisesJob, UpdateExercisesJob>();
            services.AddScoped(_ => new SqlConnection(sqlConnectionString));
            services.AddScoped<IBackgroundJobClientService, BackgroundJobClientService>();
            services.AddScoped<IDatabaseAccessService, DatabaseAccessService>();
            services.AddScoped<ICacheAccessService, CacheAccessService>();
            services.AddHangfire(configuration =>
            {
                configuration
                    .UseMemoryStorage();
            });
            services.AddCacheManagerConfiguration(configure =>
                configure
                .WithMicrosoftMemoryCacheHandle()
                .WithExpiration(ExpirationMode.Absolute, TimeSpan.FromHours(1)));
            services.AddCacheManager();
            return services;
        }
    }
}
