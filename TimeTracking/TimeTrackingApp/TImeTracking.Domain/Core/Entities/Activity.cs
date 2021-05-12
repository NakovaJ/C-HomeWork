using System;
using System.Collections.Generic;
using System.Text;
using TImeTracking.Domain.Core.Interfaces;

namespace TImeTracking.Domain.Core.Entities
{
    public abstract class Activity : BaseEntity,IActivity
    {
 
        public TimeSpan TimeSpentOnActivityThisTime { get; set; }
        public DateTime TotalTimeSpentOnActivity { get; set; }

        public TimeSpan TrackActivity()
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
            TotalTimeSpentOnActivity += TimeSpentOnActivityThisTime;
            return TimeSpentOnActivityThisTime;
        }
  
    }
}
