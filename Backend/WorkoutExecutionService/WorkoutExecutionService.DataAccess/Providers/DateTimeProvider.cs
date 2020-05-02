using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutExecutionService.DataAccess.Providers
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetDate()
        {
            return DateTime.Now;
        }
    }
}
