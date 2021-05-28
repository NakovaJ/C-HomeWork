using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeTracking.Services.Helpers;
using TimeTracking.Services.Interfaces;
using TImeTracking.Domain.Core.Enums;

namespace TimeTracking.Services.Implementation
{
    public class UIService : IUIService
    {
        public List<string> MainMenuItems { get; set; }
        public List<string> AccountMenuItems { get; set; }

        public List<string> ActivitiesMenuItems { get; set; }


        public void WelcomeToApp()
        {
            Console.WriteLine("Welcome to TimeTracking App!");
            Console.WriteLine("Here you can track your activities and improve your habits instantly!");
        }
        public int LoginRegisterMenu()
        {
            List<string> loginRegisterList = new List<string>() { "Login HERE!", "Register HERE!" };
                int loginRegisterCounter = 0;

            while (true)
            {
                if (loginRegisterCounter == 3)
                {
                    MessageHelper.Color("Sorry you tried 3 times and you did not entered correct username and password!", ConsoleColor.Red);
                    MessageHelper.Color("Goodbye!", ConsoleColor.Red);
                    return 0;
                }
                Console.WriteLine();
                Console.WriteLine("In order to start please choose a number!");
                for(int x = 0; x< loginRegisterList.Count; x++)
                {
                    Console.WriteLine($"{x+1}. {loginRegisterList[x]}");
                }
                int userChoice = ValidationHelper.ValidateNumber(Console.ReadLine(), 0,loginRegisterList.Count);
                if (userChoice == -1)
                {
                    MessageHelper.Color("[Error] Please choose only from the given options!",ConsoleColor.Red);
                    Console.ReadLine();
                    Console.Clear();
                    loginRegisterCounter++;
                    continue;
                }
                return userChoice;
            }
        }
        public int ChooseMenu<T>(List<T> items)
        {
            Console.Clear();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter a number to choose one of the following:");
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine($"{i + 1}) {items[i]}");
                }
                int choice = ValidationHelper.ValidateNumber(Console.ReadLine(), 0,items.Count);
                if (choice == -1)
                {
                    MessageHelper.Color("[Error] Input incorrect. Please try again", ConsoleColor.Red);
                    Console.ReadLine();
                    continue;
                }
                return choice;
            }
        }
        public int MainMenu()
        {
            MainMenuItems = new List<string>() { "Track Time","Your Statistics","Your Account", "Log Out" };
           
            return ChooseMenu(MainMenuItems);
        }

        public int AccountMenu()
        {
            AccountMenuItems = new List<string>() { "Change Password", "Change First/LastName", "Deactivate Account", "Back to main menu" };
            return ChooseMenu(AccountMenuItems);
        }
        public int StatisticsMenu()
        {
            List<string> StatisticsMenuItems = Enum.GetNames(typeof(ActivityType)).ToList();
            StatisticsMenuItems.Add("General");
            StatisticsMenuItems.Add("Back to main menu!");
            return ChooseMenu(StatisticsMenuItems);
        }
        public int ActivitiesMenu()
        {
             ActivitiesMenuItems = Enum.GetNames(typeof(ActivityType)).ToList();
            ActivitiesMenuItems.Add("Go back to main menu!");

            return ChooseMenu(ActivitiesMenuItems);
        }

        public int ReadingTypes()
        {
            List<string> ReadingList = Enum.GetNames(typeof(ReadingType)).ToList();
            return ChooseMenu(ReadingList);
        }
        public int ExerciseTypes()
        {
            List<string> ExerciseList = Enum.GetNames(typeof(ExercisingType)).ToList();
            return ChooseMenu(ExerciseList);
        }
        public int WorkingPlace()
        {
            List<string> WorkingLocation = Enum.GetNames(typeof(WorkinType)).ToList();
            return ChooseMenu(WorkingLocation);
        }
    }
}
