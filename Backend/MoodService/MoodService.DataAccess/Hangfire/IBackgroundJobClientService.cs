using System;
using System.Linq.Expressions;

namespace MoodService.DataAccess.Hangfire
{
    public interface IBackgroundJobClientService
    {
        void Enqueue<T>(Expression<Action<T>> methodCall);
    }
}