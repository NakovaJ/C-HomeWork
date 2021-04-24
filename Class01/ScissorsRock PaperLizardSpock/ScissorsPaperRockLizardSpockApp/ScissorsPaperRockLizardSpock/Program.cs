using System;
using System.Collections.Generic;
using AppClassLibrary.AppEntities;
using AppClassLibrary.AppServices;

namespace ScissorsPaperRockLizardSpock
{
    class Program
    {
        static void Main(string[] args)
        {
            //3.Create a console application that plays rock -paper - scissors 🔹
            //There should be a menu with three options:
            //Play
            //The user picks rock paper or scissors option
            //The application picks rock paper scissors on random
            //The user pick and the application pick are shown on the screen
            //The application shows the winner
            //The application saves 1 score to the user or the computer in the background
            //When the user hits enter it returns to the main menu
            //Stats
            //It shows how many wins the user and how many wins the computer has
            //It shows percentage of the wins and loses of the user
            //When the user hits enter it returns to the main menu
            //Exit
            //It closes the application
            int usersPoints = 0;
            int computerPoints = 0;
            int timesPlayed = 0;
            List<int> points = new List<int>() { usersPoints, computerPoints,timesPlayed };

            for (; ; )
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Welcome to this awesome Scissors-Paper-Rock-Lizard-Spock App!");
                Console.WriteLine();
                Console.WriteLine("Please select a number from the menu!");
                Console.WriteLine("Press 1 -----> to play!");
                Console.WriteLine("Press 2 -----> to check statistics!");
                Console.WriteLine("Press x -----> to exit!");
                Console.WriteLine();

                string userChoice = Console.ReadLine();
                if (userChoice == "x") break;

                switch (userChoice)
                {
                    case "1":
                        points =AppService.PlayGame(points);
                        break;
                    case "2":
                        AppService.Stats(points);
                        break;
                }

            }
        }
    }
}
