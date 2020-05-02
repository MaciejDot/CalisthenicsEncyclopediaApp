using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutExecutionService.DataAccess.Providers
{
    public class GuidProvider : IGuidProvider
    {
        public Guid GetGuid()
        {
            return Guid.NewGuid();
        }
    }
}
