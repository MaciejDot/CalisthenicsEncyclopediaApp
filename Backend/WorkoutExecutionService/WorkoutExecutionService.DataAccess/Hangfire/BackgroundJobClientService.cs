using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace WorkoutExecutionService.DataAccess.Hangfire
{
    public class BackgroundJobClientService : IBackgroundJobClientService
    {
        public void Schedule<T>(Expression<Action<T>> methodCall, TimeSpan delay)
        {
            BackgroundJob.Schedule<T>(methodCall, delay);
        }

        public void Enqueue<T>(Expression<Action<T>> methodCall)
        {
            BackgroundJob.Enqueue<T>(methodCall);
        }
    }
}
