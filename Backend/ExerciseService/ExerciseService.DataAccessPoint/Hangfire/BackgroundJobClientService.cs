using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExerciseService.DataAccessPoint.Hangfire
{
    public class BackgroundJobClientService : IBackgroundJobClientService
    {
        public void Enqueue<TInterface>(Expression<Action<TInterface>> methodCall)
        {
            BackgroundJob.Enqueue<TInterface>(methodCall);
        }
    }
}
