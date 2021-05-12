using System;
using System.Collections.Generic;
using System.Text;
using TImeTracking.Domain.Core.Enums;
using TImeTracking.Domain.Core.Interfaces;
namespace TImeTracking.Domain.Core.Entities
{
    public class Working : Activity,IWork
    {
        WorkinType TypeOfWorking { get; set; }
        public override void Print()
        {
            Console.WriteLine($"Currently working -- Total hours spent on work {TotalTimeSpentOnActivity} so far!");

        }

        public void SelectWorkingLocation()
        {
            while (true)
            {

                Console.WriteLine("Please select where were you working from!");
                Console.WriteLine("1. From home");
                Console.WriteLine("2. At office");
                string userInput = Console.ReadLine();
                if (userInput == "1" || userInput == "2")
                {
                    switch (userInput)
                    {
                        case "1":
                            TypeOfWorking = WorkinType.FromHome;
                            break;
                        case "2":
                            TypeOfWorking = WorkinType.AtOffice;
                            break;
                    }
                    break;
                }
            }

        }
    }
}
