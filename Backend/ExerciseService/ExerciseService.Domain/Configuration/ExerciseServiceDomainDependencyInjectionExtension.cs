using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ExerciseService.Domain.Configuration
{
    public static class ExerciseServiceDomainDependencyInjectionExtension
    {
        public static IServiceCollection AddExerciseServiceDomain(this IServiceCollection services) {
            return services.AddMediatR(Assembly.GetExecutingAssembly());

        }
    }
}
