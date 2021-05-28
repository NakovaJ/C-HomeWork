using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TImeTracking.Domain.Core.Interfaces;

namespace TImeTracking.Domain.Core.Entities
{
    public class OtherHobies:Activity,IHobby
    {
        public string NameOfHobby { get; set; }

        public OtherHobies()
        {
            TypeOfActivity = Enums.ActivityType.OtherHobbies;
        }
        public override TimeSpan TrackActivity()
        {
            DateTime first = DateTime.Now;
            DateTime second;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Curentlly doing your hobby");
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
            Console.WriteLine("Press enter when you finish doing your hobby!");
            while (true)
            {
                if (Console.ReadLine() == "")
                {
                    second = DateTime.Now;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have finished doing your hobby!");
                    Console.WriteLine();
                    Console.ResetColor();
                    break;
                }

            }
            TimeSpentOnActivityThisTime = second - first;
            TotalTimeActivity += TimeSpentOnActivityThisTime;
            return TimeSpentOnActivityThisTime;
        }
        public void EnterNameOfHobby()
        {
            string userInput;
            while (true)
            {
                Console.WriteLine("Please enter a name of the hobby you did!");
                userInput = Console.ReadLine();
                if (userInput != "") break;
            }
           
            userInput = userInput.ToLower();
            userInput = userInput[0].ToString().ToUpper() + userInput.Substring(1);
            NameOfHobby = userInput;
        }

        public override void Print()
        {
            Console.WriteLine($"Currently doing other hobbies -- Total hours spent on hobbies {TotalTimeActivity} so far!");

        }

    }
}
