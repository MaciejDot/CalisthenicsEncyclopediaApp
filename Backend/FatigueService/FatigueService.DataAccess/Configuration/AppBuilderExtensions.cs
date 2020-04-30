using FatigueService.DataAccess.Jobs;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace FatigueService.DataAccess.Configuration
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder UseMoodServiceDataAccess(this IApplicationBuilder app, IBackgroundJobClient backgroundJobClient)
        {
            app.UseHangfireServer();
            backgroundJobClient.Enqueue<IPopulateFatiguesJob>(x => x.Run());
            return app;
        }
    }
}
