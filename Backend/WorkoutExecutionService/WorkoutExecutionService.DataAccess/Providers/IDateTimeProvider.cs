using System;

namespace WorkoutExecutionService.DataAccess.Providers
{
    public interface IDateTimeProvider
    {
        DateTime GetDate();
    }
}