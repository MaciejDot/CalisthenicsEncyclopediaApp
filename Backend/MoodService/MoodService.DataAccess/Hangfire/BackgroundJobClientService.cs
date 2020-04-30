using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MoodService.DataAccess.Hangfire
{
    public class BackgroundJobClientService : IBackgroundJobClientService
    {
        public void Enqueue<T>(Expression<Action<T>> methodCall)
        {
            BackgroundJob.Enqueue<T>(methodCall);
        }
    }
}
