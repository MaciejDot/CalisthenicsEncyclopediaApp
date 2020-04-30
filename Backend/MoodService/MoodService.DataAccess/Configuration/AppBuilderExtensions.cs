using Hangfire;
using Microsoft.AspNetCore.Builder;
using MoodService.DataAccess.Jobs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoodService.DataAccess.Configuration
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder UseMoodServiceDataAccess(this IApplicationBuilder app, IBackgroundJobClient backgroundJobClient)
        {
            app.UseHangfireServer();
            backgroundJobClient.Enqueue<IPopulateMoodCacheJob>(x => x.Run());
            return app;
        }
    }
}
