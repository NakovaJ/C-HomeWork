using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TImeTracking.Domain.Core.Enums;
using TImeTracking.Domain.Core.Interfaces;

namespace TImeTracking.Domain.Core.Entities
{
    public class Exercising : Activity,IExercise
    {
        public ExercisingType TypeOfExercise { get; set; }
        public Exercising()
        {
            TypeOfActivity = ActivityType.Exercising;
        }
        public override void Print()
        {
            Console.WriteLine($"Currently exercising -- Total hours spent on exercising {TotalTimeActivity}h so far!");

        }
        public override TimeSpan TrackActivity()
        {
            DateTime first = DateTime.Now;
            DateTime second;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Curentlly exercising ");
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
            Console.WriteLine("Press enter when you finish exercising!");
            while (true)
            {
                if (Console.ReadLine() == "")
                {
                    second = DateTime.Now;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have finished exercising!");
                    Console.WriteLine();
                    Console.ResetColor();
                    break;
                }

            }
            TimeSpentOnActivityThisTime = second - first;
            TotalTimeActivity += TimeSpentOnActivityThisTime;
            return TimeSpentOnActivityThisTime;
        }

        public void SelectTypeOfExercise(int x)
        {
            
                    switch (x)
                    {
                        case 1:
                            TypeOfExercise = ExercisingType.General;
                            break;
                        case 2:
                            TypeOfExercise = ExercisingType.Running;
                            break;
                        case 3:
                            TypeOfExercise = ExercisingType.Footbal;
                            break;
                        case 4:
                            TypeOfExercise = ExercisingType.Tennis;
                            break;
                        case 5:
                            TypeOfExercise = ExercisingType.Yoga;
                            break;
                        case 6:
                            TypeOfExercise = ExercisingType.Pillates;
                            break;
                        case 7:
                            TypeOfExercise = ExercisingType.OtherSport;
                            break;
                    }
            

           


        }
    }
}
