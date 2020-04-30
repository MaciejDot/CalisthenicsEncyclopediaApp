using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace WorkoutExecutionService.Domain.Configuration
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddWorkoutExecutionServiceDomain(this IServiceCollection services) 
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        } 
    }
}
