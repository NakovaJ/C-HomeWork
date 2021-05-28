using System;
using System.Collections.Generic;
using System.Text;
using TImeTracking.Domain.Core.Interfaces;
using TImeTracking.Domain.Core.Enums;
using System.Linq;
using System.Threading;

namespace TImeTracking.Domain.Core.Entities
{
    public class Reading : Activity, IRead
    {
        
        public int Pages { get; set; }
        public ReadingType TypeOfBook { get; set; }

        public Reading()
        {
            TypeOfActivity = ActivityType.Reading;
        }
        public override void Print()
        {
            Console.WriteLine($"Currently reading {TypeOfBook} -- Total pages read {Pages} so far! Total time spent on reading {TotalTimeActivity} so far");
        }

        public override TimeSpan TrackActivity()
        {
            DateTime first = DateTime.Now;
            DateTime second;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Curentlly reading ");
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
            Console.WriteLine("Press enter when you finish reading!");
            Console.WriteLine();
            while (true)
            {
        
                if (Console.ReadLine() == "")
                {
                    second = DateTime.Now;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have finished reading!");
                    Console.WriteLine();
                    Console.ResetColor();
                    break;
                }
                else continue;
                

            }
            TimeSpentOnActivityThisTime = second - first;
            TotalTimeActivity += TimeSpentOnActivityThisTime;
            return TimeSpentOnActivityThisTime;
        }

        public int EnterPagesRead()
        {
            int numberOfPages = 0;
            while (true)
            {

                Console.WriteLine("Please enter how many pages you read this time!");
                string userInput = Console.ReadLine();
                bool succesfulParsing = int.TryParse(userInput, out numberOfPages);
                if (succesfulParsing) break;
               
            }
            Pages += numberOfPages;
            return numberOfPages;
        }


        public void SelectTypeOfLiterature(int x)
        {

          
            switch (x)
            {
                case 1:
                    TypeOfBook = ReadingType.BelleLetters;
                    break;
                case 2:
                    TypeOfBook = ReadingType.Fiction;
                    break;
                case 3:
                    TypeOfBook = ReadingType.ProfessionalLiterature;
                    break;
                case 4:
                    TypeOfBook = ReadingType.MotivationalLiterature;
                    break;
                case 5:
                    TypeOfBook = ReadingType.SpiritualLiterature;
                    break;
                case 6:
                    TypeOfBook = ReadingType.ReadingToYourKids;
                    break;
            }
        
        }

        public void SelectTypeOfLiterature()
        {
            throw new NotImplementedException();
        }
    }
}
