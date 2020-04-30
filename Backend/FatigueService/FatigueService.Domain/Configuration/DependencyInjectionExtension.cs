using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FatigueService.Domain.Configuration
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddFatigueServiceDomain(this IServiceCollection services) 
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
