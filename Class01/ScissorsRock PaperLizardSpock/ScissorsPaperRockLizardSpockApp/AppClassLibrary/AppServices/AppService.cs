using AppClassLibrary.AppEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AppClassLibrary.AppServices
{
    public static class AppService
    {
     

        #region PlayGame
        public static List<int> PlayGame(List<int> somePoints)
        {


            for (; ; )
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Time to play Rock-Paper-Scissors!");
                Console.WriteLine();

                Console.WriteLine("Please choose from the given options!");
                Console.WriteLine("Press 1 ----> for SCISSORS");
                Console.WriteLine("Press 2 ----> for PAPER");
                Console.WriteLine("Press 3 ----> for ROCK");
                Console.WriteLine("Press 4 ----> for LIZARD");
                Console.WriteLine("Press 5 ----> for SPOCK");
                Console.WriteLine("Press Enter ----> to go back!");

                Array values = Enum.GetValues(typeof(AppEnum));
                Random random = new Random();
                AppEnum randomPick = (AppEnum)values.GetValue(random.Next(values.Length));
            

                string userInput = Console.ReadLine();

                if (userInput == "")
                {
                    return somePoints;

                }
                if (userInput == "1" || userInput == "2" || userInput == "3" || userInput=="4" || userInput=="5")
                {
                    Console.WriteLine($"You choose {values.GetValue(int.Parse(userInput)-1).ToString().ToUpper()}!");
                    Console.WriteLine($"The computer choose {randomPick.ToString().ToUpper()}!");

                    switch (userInput)
                    {
                        case "1":
                            switch (randomPick)
                            {
                             
                                case AppEnum.Paper:
                                case AppEnum.Lizard:
                                    Console.WriteLine("Therefore you won now!");
                                    Console.WriteLine("1 point goes for you!");
                                    somePoints[0]++;
                                    break;
                                case AppEnum.Scissors:
                                    Console.WriteLine("Noone wins this time!");
                                    break;
                                case AppEnum.Rock:
                                case AppEnum.Spock:
                                    Console.WriteLine("Therefore you lost now!");
                                    Console.WriteLine("1 point goes for the computer player");
                                    somePoints[1]++;
                                    break;
                            }
                            break;
                        case "2":
                            switch (randomPick)
                            {
                                case AppEnum.Rock:
                                case AppEnum.Spock:
                                    Console.WriteLine("Therefore you won now!");
                                    Console.WriteLine("1 point goes for you!");
                                    somePoints[0]++;
                                    break;
                                case AppEnum.Paper:
                                    Console.WriteLine("Noone wins this time!");
                                    break;
                                case AppEnum.Scissors:
                                case AppEnum.Lizard:
                                    Console.WriteLine("Therefore you lost now!");
                                    Console.WriteLine("1 point goes for the computer player");
                                    somePoints[1]++;
                                    break;   
                            }
                            break;
                        case "3":
                            switch (randomPick)
                            {
                                case AppEnum.Scissors:
                                case AppEnum.Lizard:
                                    Console.WriteLine("Therefore you won now!");
                                    Console.WriteLine("1 point goes for you!");
                                    somePoints[0]++;
                                    break;
                                case AppEnum.Rock:
                                    Console.WriteLine("Noone wins this time!");
                                    break;
                                case AppEnum.Paper:
                                case AppEnum.Spock:
                                    Console.WriteLine("Therefore you lost now!");
                                    Console.WriteLine("1 point goes for the computer player");
                                    somePoints[1]++;
                                    break;
                            }
                            break;
                        case "4":
                            switch (randomPick)
                            {
                                case AppEnum.Spock:
                                case AppEnum.Paper:
                                    Console.WriteLine("Therefore you won now!");
                                    Console.WriteLine("1 point goes for you!");
                                    somePoints[0]++;
                                    break;
                                case AppEnum.Lizard:
                                    Console.WriteLine("Noone wins this time!");
                                    break;
                                case AppEnum.Scissors:
                                case AppEnum.Rock:
                                    Console.WriteLine("Therefore you lost now!");
                                    Console.WriteLine("1 point goes for the computer player");
                                    somePoints[1]++;
                                    break;
                            }
                            break;
                        case "5":
                            switch (randomPick)
                            {
                                case AppEnum.Scissors:
                                case AppEnum.Rock:
                                    Console.WriteLine("Therefore you won now!");
                                    Console.WriteLine("1 point goes for you!");
                                    somePoints[0]++;
                                    break;
                                case AppEnum.Spock:
                                    Console.WriteLine("Noone wins this time!");
                                    break;
                                case AppEnum.Paper:
                                case AppEnum.Lizard:
                                    Console.WriteLine("Therefore you lost now!");
                                    Console.WriteLine("1 point goes for the computer player");
                                    somePoints[1]++;
                                    break;
                            }
                            break;

                    }
                    somePoints[2]++;
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

        #region Statistics Of Played Games
        public static void Stats(List<int> points)
        {
            for (; ; )
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Game statistics:");
                Console.WriteLine();
                Console.WriteLine($"You have {points[0]} wins!");
                Console.WriteLine("VS");
                Console.WriteLine($"The computer has {points[1]} wins!");
                Console.WriteLine();
                Console.WriteLine($"In total you played {points[2]} games!");
                Console.WriteLine($"There were {points[2]-(points[0]+points[1])} games where you and the computer had the same choise!");

                try
                {
                    decimal userWins = (decimal)points[0] / points[2];

                    decimal computerWins = (decimal)points[1] / points[2];

                    decimal userWins2 = (decimal)points[0] / (points[0] + points[1]);

                    decimal computerWins2 = (decimal)points[1] / (points[0]+points[1]);

                    string displayUserWins = string.Format("{0:P}", userWins);
                    string displayComputerWins = string.Format("{0:P}", computerWins);
                    string displayUserWins2 = string.Format("{0:P}", userWins2);
                    string displayComputerWins2 = string.Format("{0:P}", computerWins2);

                    Console.WriteLine();
                    Console.WriteLine("If taken in account the games where there was no winner, calculated in percents:");
                    Console.WriteLine($"You have {displayUserWins} wins!");
                    Console.WriteLine($"The computer has {displayComputerWins} wins!");
                    Console.WriteLine();
                    Console.WriteLine("If taken in account only the games with winner, calculated in percents:");
                    Console.WriteLine($"You have {displayUserWins2} wins!");
                    Console.WriteLine($"The computer has {displayComputerWins2} wins!");
                    Console.WriteLine();

                }
                catch (Exception ex)
                {

                }
                Console.WriteLine("Press enter -----> to go back!");
                if (Console.ReadLine() == "") break;

            }

        }
        #endregion
    }
}
