using Microsoft.Extensions.DependencyInjection;
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
            return services;
        }
    }
}
