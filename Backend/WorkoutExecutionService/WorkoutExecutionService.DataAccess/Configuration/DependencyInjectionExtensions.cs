using CacheManager.Core;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;
using SimpleCQRS.DependencyInjectionExtensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using WorkoutExecutionService.DataAccess.Cache;
using WorkoutExecutionService.DataAccess.Hangfire;
using WorkoutExecutionService.DataAccess.Jobs;
using WorkoutExecutionService.DataAccess.Providers;
using WorkoutExecutionService.DataAccess.Repositories;
using WorkoutExecutionService.DataAccessPoint.Cache;

namespace WorkoutExecutionService.DataAccess.Configuration
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddWorkoutExecutionServiceDataAccessOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ExerciseServiceOptions>(configuration.GetSection("ExerciseService"));
            services.Configure<FatigueServiceOptions>(configuration.GetSection("FatigueService"));
            services.Configure<MoodServiceOptions>(configuration.GetSection("MoodService"));
            return services;
        }


        public static IServiceCollection AddWorkoutExecutionServiceDataAccess(this IServiceCollection services, string sqlConnectionString)
        {
            services.AddSingleton<IRestClient, RestClient>();
            services.AddSingleton<IWorkoutExecutionCacheService, WorkoutExecutionCacheService>();
            services.AddSingleton<IFatigueCacheService, FatigueCacheService>();
            services.AddSingleton<IMoodCacheService, MoodCacheService>();
            services.AddSingleton<IMoodsRepository, MoodsRepository>();
            services.AddSingleton<IFatiguesRepository, FatiguesRepository>();
            services.AddSingleton<IWorkoutExecutionRepository, WorkoutExecutionRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IExerciseRepository, ExerciseRepository>();
            services.AddTransient(_ => new SqlConnection(sqlConnectionString));
            services.AddSingleton<IUserCacheService, UserCacheService>();
            services.AddSingleton<IExerciseCacheService, ExerciseCacheService>();
            services.AddSingleton<IBackgroundJobClientService, BackgroundJobClientService>();

            services.AddTransient<IDeleteWorkoutExecutionJob, DeleteWorkoutExecutionJob>();
            services.AddTransient<IAddWorkoutExecutionJob, AddWorkoutExecutionJob>();
            services.AddTransient<IPopulateExercisesJob, PopulateExercisesJob>();
            services.AddTransient<IPopulateFatiguesJob, PopulateFatiguesJob>();
            services.AddTransient<IPopulateMoodsJob, PopulateMoodsJob>();
            services.AddTransient<IPopulateUsersJob, PopulateUsersJob>();
            services.AddTransient<IPopulateWorkoutsJob, PopulateWorkoutsJob>();
            services.AddTransient<IUpdateWorkoutExecutionJob, UpdateWorkoutExecutionJob>();

            services.AddSingleton<IGuidProvider, GuidProvider>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddSimpleCQRS(Assembly.GetExecutingAssembly());
            services.AddHangfire(configuration =>
            {
                configuration
                    .UseMemoryStorage();
            });
            services.AddCacheManagerConfiguration(configure =>
                configure
                .WithMicrosoftMemoryCacheHandle()
                .WithExpiration(ExpirationMode.Absolute, TimeSpan.FromMinutes(10)));
            services.AddCacheManager();
            return services;

        }
    }
}
