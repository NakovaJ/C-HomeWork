using System;
using System.Collections.Generic;
using System.Text;

namespace TImeTracking.Domain.Core.Interfaces
{
   public interface IActivity
    {
 
        TimeSpan TimeSpentOnActivityThisTime { get; set; }
        DateTime TotalTimeSpentOnActivity { get; set; }

        TimeSpan TrackActivity();
    }
}
