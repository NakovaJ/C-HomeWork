using System;
using System.Collections.Generic;
using System.Text;

namespace TImeTracking.Domain.Core.Interfaces
{
   public interface IActivity
    {
 
        TimeSpan TimeSpentOnActivityThisTime { get; set; }
        TimeSpan TotalTimeActivity { get; set; }

        TimeSpan TrackActivity();
    }
}
