using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using RokPaperScissorsClassLibrary.Models;

namespace RokPaperScissorsClassLibrary.Services
{
   
    public static class GameService
    {

        #region Game Service
        public static List<int> PlayGame(List<int> somePoints)
        {
         

           for (; ; )
           {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Time to play Rock-Paper-Scissors!");
                Console.WriteLine();

                Console.WriteLine("Please choose from the given options!");
                Console.WriteLine("Press 1 ----> for ROCK");
                Console.WriteLine("Press 2 ----> for PAPER");
                Console.WriteLine("Press 3 ----> for SCISSORS");
                Console.WriteLine("Press Enter ----> to go back!");

                Array values = Enum.GetValues(typeof(GameEnum));
                Random random = new Random();
                GameEnum randomPick = (GameEnum)values.GetValue(random.Next(values.Length));

                string userInput = Console.ReadLine();
               
                if (userInput == "")
                {
                    return somePoints;

                }
                if (userInput=="1" || userInput=="2" || userInput == "3")
                {
                    switch (userInput)
                    {
                        case "1":
                            switch (randomPick)
                            {
                                case GameEnum.Paper:
                                    Console.WriteLine("You choose ROCK and the computer player choose PAPER!");
                                    Console.WriteLine("Therefore you lost now!");
                                    Console.WriteLine("1 point goes for the computer player");
                                    somePoints[1]++;
                                    break;
                                case GameEnum.Rock:
                                    Console.WriteLine("You choose ROCK and the computer player choose ROCK!");
                                    Console.WriteLine("Noone wins this time!");
                                    break;
                                case GameEnum.Scissors:
                                    Console.WriteLine("You choose ROCK and the computer player choose SCISSORS!");
                                    Console.WriteLine("Therefore you won now!");
                                    Console.WriteLine("1 point goes for you!");
                                    somePoints[0]++;
                                    break;
                            }
                            break;
                        case "2":
                            switch (randomPick)
                            {
                                case GameEnum.Paper:
                                    Console.WriteLine("You choose PAPER and the computer player choose PAPER!");
                                    Console.WriteLine("Noone wins this time!");
                                    break;
                                case GameEnum.Rock:
                                    Console.WriteLine("You choose PAPER and the computer player choose ROCK!");
                                    Console.WriteLine("Therefore you won now!");
                                    Console.WriteLine("1 point goes for you!");
                                    somePoints[0]++;
                                    break;
                                case GameEnum.Scissors:
                                    Console.WriteLine("You choose PAPER and the computer player choose SCISSORS!");
                                    Console.WriteLine("Therefore you lost now!");
                                    Console.WriteLine("1 point goes for the computer player");
                                    somePoints[1]++;
                                    break;
                            }
                            break;
                        case "3":
                            switch (randomPick)
                            {
                                case GameEnum.Paper:
                                    Console.WriteLine("You choose SCISSORS and the computer player choose PAPER!");
                                    Console.WriteLine("Therefore you won now!");
                                    Console.WriteLine("1 point goes for you!");
                                    somePoints[0]++;
                                    break;
                                case GameEnum.Rock:
                                    Console.WriteLine("You choose SCISSORS and the computer player choose ROCK!");
                                    Console.WriteLine("Therefore you lost now!");
                                    Console.WriteLine("1 point goes for the computer player");
                                    somePoints[1]++;
                                    break;
                                case GameEnum.Scissors:
                                    Console.WriteLine("You choose SCISSORS and the computer player choose SCISSORS!");
                                    Console.WriteLine("Noone wins this time!");
                                    break;
                            }
                            break;
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Press Enter ----> to go back!");
                Console.WriteLine("Press any other key-----> to play agin!");
                if (Console.ReadLine() == "")
                {
                    return somePoints;
                } 




            }
        }
        #endregion

        #region Stats
        public static void Stats(List<int>points)
        {
            for(; ; )
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Game statistics:");
                Console.WriteLine();
                Console.WriteLine($"You have {points[0]} wins!");
                Console.WriteLine("VS");
                Console.WriteLine($"The computer has {points[1]} wins!");
                Console.WriteLine();

                try
                {
                    decimal userWins = (decimal)points[0] / points.Sum();

                    decimal computerWins = (decimal)points[1] / points.Sum();

                   
                    var displayUserWins = string.Format("{0:P}", userWins);
                    var displayComputerWins = string.Format("{0:P}", computerWins);
                    Console.WriteLine("If calculated in percents:");
                    Console.WriteLine($"You have {displayUserWins} wins!");
                    Console.WriteLine($"The computer has {displayComputerWins} wins!");
                    Console.WriteLine();
                  
                }
                catch(Exception ex)
                {

                }
                Console.WriteLine("Press enter -----> to go back!");
                if (Console.ReadLine() == "") break;

            }

        }
        #endregion
    }



}