using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExerciseService.DataAccessPoint.Hangfire
{
    public interface IBackgroundJobClientService
    {
        void Enqueue<TInterface>(Expression<Action<TInterface>> methodCall);
    }
}
