using ExerciseService.DataAccessPoint.Jobs;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseService.DataAccessPoint.Configuration
{
    public static class ExerciseServiceDataAccessPointApplicationBuilderExtension
    {
        public static IApplicationBuilder UseExerciseServiceDataAccessPoint(this IApplicationBuilder app)
        {
            app.UseHangfireServer();
            BackgroundJob.Enqueue<IUpdateExercisesJob>(x => x.Run(default));
            return app;
        }
    }
}
