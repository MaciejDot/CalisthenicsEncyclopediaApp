using Hangfire;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;
using WorkoutExecutionService.DataAccess.Jobs;

namespace WorkoutExecutionService.DataAccess.Configuration
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder UseWorkoutExecutionServiceDataAccess(this IApplicationBuilder app, IBackgroundJobClient backgroundJobClient)
        {
            app.UseHangfireServer();
            backgroundJobClient.Enqueue<IPopulateExercisesJob>(x => x.Run());
            backgroundJobClient.Enqueue<IPopulateWorkoutsJob>(x => x.Run());
            backgroundJobClient.Enqueue<IPopulateUsersJob>(x => x.Run());
            backgroundJobClient.Enqueue<IPopulateMoodsJob>(x => x.Run());
            backgroundJobClient.Enqueue<IPopulateFatiguesJob>(x => x.Run());
            return app;
        }
    }
}
