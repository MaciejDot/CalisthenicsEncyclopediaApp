using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MoodService.Domain.Configuration
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddMoodServiceDomain(this IServiceCollection services) 
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
