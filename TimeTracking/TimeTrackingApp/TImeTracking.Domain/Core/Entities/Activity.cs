using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TImeTracking.Domain.Core.Enums;
using TImeTracking.Domain.Core.Interfaces;

namespace TImeTracking.Domain.Core.Entities
{
    public abstract class Activity : BaseEntity,IActivity
    {
       public ActivityType TypeOfActivity { get; set; }

        public TimeSpan TimeSpentOnActivityThisTime { get; set; }
        public TimeSpan TotalTimeActivity { get; set; }

        public int UserDoingActivityId { get; set; }
        public virtual TimeSpan TrackActivity()
        {
            DateTime first = DateTime.Now;
            DateTime second;

        
            while (true)
            {
      
                if (Console.ReadLine() == "")
                {
                    second = DateTime.Now;
                    break;
                }

            }
            TimeSpentOnActivityThisTime = second - first;
            TotalTimeActivity += TimeSpentOnActivityThisTime;
            return TimeSpentOnActivityThisTime;
        }
  
    }
}
