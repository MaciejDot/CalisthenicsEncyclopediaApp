using System;
using System.Linq.Expressions;

namespace WorkoutExecutionService.DataAccess.Hangfire
{
    public interface IBackgroundJobClientService
    {
        void Enqueue<T>(Expression<Action<T>> methodCall);
        void Schedule<T>(Expression<Action<T>> methodCall, TimeSpan delay);
    }
}