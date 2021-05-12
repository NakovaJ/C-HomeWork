using System;
using System.Collections.Generic;
using System.Text;
using TImeTracking.Domain.Core.Interfaces;
using TImeTracking.Domain.Core.Enums;

namespace TImeTracking.Domain.Core.Entities
{
    public class Reading : Activity, IRead
    {
        public int Pages { get; set; }
        public ReadingType TypeOfBook { get; set; }

        public override void Print()
        {
            Console.WriteLine($"Currently reading {TypeOfBook} -- Total pages read {Pages} so far! Total time spent on reading {TotalTimeSpentOnActivity} so far");
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
                else { Console.WriteLine("Please enter a number!"); };
            }
            Pages += numberOfPages;
            return numberOfPages;
        }

        public void SelectTypeOfLiterature()
        {
            while (true)
            {
                Console.WriteLine("Please select the number from the listed types of books, you read this time!");
                Console.WriteLine("1.BelleLetters");
                Console.WriteLine("2.Fiction");
                Console.WriteLine("3.Professional Literature");
                Console.WriteLine("4.Motivational Literature");
                Console.WriteLine("5.Spiritual Literature");
                Console.WriteLine("6.Reading to your kids");

                string userInput = Console.ReadLine();
                if (userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4" || userInput == "5" || userInput == "6")
                {
                    switch (userInput)
                    {
                        case "1":
                            TypeOfBook = ReadingType.BelleLetters;
                            break;
                        case "2":
                            TypeOfBook = ReadingType.Fiction;
                            break;
                        case "3":
                            TypeOfBook = ReadingType.ProfessionalLiterature;
                            break;
                        case "4":
                            TypeOfBook = ReadingType.MotivationalLiterature;
                            break;
                        case "5":
                            TypeOfBook = ReadingType.SpiritualLiterature;
                            break;
                        case "6":
                            TypeOfBook = ReadingType.ReadingToYourKids;
                            break;
                    }
                    break;
                }

            }
        }
    }
}
