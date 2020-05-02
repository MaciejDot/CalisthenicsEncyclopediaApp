using System;

namespace WorkoutExecutionService.DataAccess.Providers
{
    public interface IGuidProvider
    {
        Guid GetGuid();
    }
}