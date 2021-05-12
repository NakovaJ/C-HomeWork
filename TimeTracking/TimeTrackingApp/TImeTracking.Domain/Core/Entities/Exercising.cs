using System;
using System.Collections.Generic;
using System.Text;
using TImeTracking.Domain.Core.Enums;
using TImeTracking.Domain.Core.Interfaces;

namespace TImeTracking.Domain.Core.Entities
{
    public class Exercising : Activity,IExercise
    {
        ExercisingType TypeOfExercise { get; set; }
        public override void Print()
        {
            Console.WriteLine($"Currently exercising -- Total hours spent on exercising {TotalTimeSpentOnActivity}h so far!");

        }

        public void SelectTypeOfExercise()
        {
            while (true)
            {

                Console.WriteLine("Please select the type of exercising by selecting one of the provided numbers!");
                Console.WriteLine("1.General");
                Console.WriteLine("2.Running");
                Console.WriteLine("3.Football");
                Console.WriteLine("4.Tennis");
                Console.WriteLine("5.Yoga");
                Console.WriteLine("6.Pillates");
                Console.WriteLine("7.OtherSport");

                string userInput = Console.ReadLine();
                if (userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4" || userInput == "5" || userInput == "6" || userInput == "7")
                {
                    switch (userInput)
                    {
                        case "1":
                            TypeOfExercise = ExercisingType.General;
                            break;
                        case "2":
                            TypeOfExercise = ExercisingType.Running;
                            break;
                        case "3":
                            TypeOfExercise = ExercisingType.Footbal;
                            break;
                        case "4":
                            TypeOfExercise = ExercisingType.Tennis;
                            break;
                        case "5":
                            TypeOfExercise = ExercisingType.Yoga;
                            break;
                        case "6":
                            TypeOfExercise = ExercisingType.Pillates;
                            break;
                        case "7":
                            TypeOfExercise = ExercisingType.OtherSport;
                            break;
                    }
                    break;
                }

            }


        }
    }
}
