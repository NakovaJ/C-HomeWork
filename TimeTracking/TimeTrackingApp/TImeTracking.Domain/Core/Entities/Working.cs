using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TImeTracking.Domain.Core.Enums;
using TImeTracking.Domain.Core.Interfaces;
namespace TImeTracking.Domain.Core.Entities
{
    public class Working : Activity,IWork
    {
       public WorkinType TypeOfWorking { get; set; }
        public Working()
        {
            TypeOfActivity = ActivityType.Working;
        }
        public override void Print()
        {
            Console.WriteLine($"Currently working -- Total hours spent on work {TotalTimeActivity} so far!");

        }
        public override TimeSpan TrackActivity()
        {
            DateTime first = DateTime.Now;
            DateTime second;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Curentlly working");
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(".");
            Thread.Sleep(1100);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(".");
            Thread.Sleep(1200);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(".");
            Console.ResetColor();
           
            Console.WriteLine();
            Console.WriteLine("Press enter when you finish wokring!");
            while (true)
            {
                if (Console.ReadLine() == "")
                {
                    second = DateTime.Now;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have finished working!");
                    Console.WriteLine();
                    Console.ResetColor();
                    break;
                }

            }
            TimeSpentOnActivityThisTime = second - first;
            TotalTimeActivity += TimeSpentOnActivityThisTime;
            return TimeSpentOnActivityThisTime;
        }
        public void SelectWorkingLocation(int x)
        {
            
                    switch (x)
                    {
                        case 1:
                            TypeOfWorking = WorkinType.FromHome;
                            break;
                        case 2:
                            TypeOfWorking = WorkinType.AtOffice;
                            break;
                    }
           

        }
    }
}
