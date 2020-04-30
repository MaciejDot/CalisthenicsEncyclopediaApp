using System;
using System.Linq.Expressions;

namespace FatigueService.DataAccess.Hangfire
{
    public interface IBackgroundJobClientService
    {
        void Enqueue<T>(Expression<Action<T>> methodCall);
    }
}