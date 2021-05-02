using System;
using QuizzMillioner.Entities.Models;
using System.Collections.Generic;

namespace QuizzMillioner
{
    class Program
    {
        static void Main(string[] args)
        {
            string playerName = "";
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please enter your name so you can start playing!");
                Console.WriteLine("It has to be at least 3 charachters long!");
                playerName = Console.ReadLine();
                if (playerName.Length >=3) break;
            }
            QuizMillionare Millionaire = new QuizMillionare(playerName,false,false,false,QuestionsDB.AllQuestions);
            Millionaire.Start();

            for (int x = 1; x <= 15; x++)
            {
                Question questionActive = Millionaire.GenerateQuestion(x);

                string userInput = "";
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Please note that you can enter only 1,2,3 or 4 as possible answers!");
                    Console.WriteLine("And you can also enter x,y or z if you want to use some help!");
                    Console.WriteLine();
                    Console.ResetColor();

                    Console.WriteLine($"Question number {x}:");
                    Millionaire.PrintQuestion(questionActive);
                    Millionaire.PrintHelpOptions();
                    userInput = Console.ReadLine().ToLower();
                    if (userInput != "1" && userInput != "2" && userInput != "3" && userInput != "4" && userInput != "x" && userInput != "y" && userInput != "z")
                    {

                        while (true)
                        {
                            Console.WriteLine("Please choose ONLY from the given options!");
                            Console.WriteLine("Please press ENTER to continue!");
                            if (Console.ReadLine() == "") break;
                        }
                        continue;
                    }
                    if (userInput == "x")
                    {
                        Millionaire.UseHelpAudience(questionActive);
                        while (true)
                        {
                            Console.WriteLine("Please press ENTER to continue!");
                            if (Console.ReadLine() == "") break;
                        }
                        continue;
                    }
                    if (userInput == "y")
                    {
                        Millionaire.UseHelpFriend(questionActive);
                        while (true)
                        {
                            Console.WriteLine("Please press ENTER to continue!");
                            if (Console.ReadLine() == "") break;
                        }
                        continue;
                    }

                    if (userInput == "z")
                    {
                        Millionaire.UseHelpFiftyFifty(questionActive);
                        while (true)
                        {
                            Console.WriteLine("Please press ENTER to continue!");
                            if (Console.ReadLine() == "") break;
                        }
                        continue;
                    }


                    if (userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4") break;

                }
                if (int.Parse(userInput) != questionActive.CorrectAnswer)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sorry that is not the correct answer!");
                    Console.WriteLine($"More luck next time {playerName}!");

                    if (x > 10) Console.WriteLine("At least you won 32000 $! Congratulations!");
                    else if (x > 5) Console.WriteLine("At least you won 1000 $! Congratulations!");
                    else Console.WriteLine("You did not win any moneny!");
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("That is correct answer!");
                    switch (x)
                    {
                        case 1:
                            Console.WriteLine($"{playerName} so far you have 100 $ but they are not guaranteed until you succesfully answer the 5th question!");
                            break;
                        case 2:
                            Console.WriteLine($"{playerName} so far you have 200 $ but they are not guaranteed until you succesfully answer the 5th question!");
                            break;
                        case 3:
                            Console.WriteLine($"{playerName} so far you have 300 $ but they are not guaranteed until you succesfully answer the 5th question!");
                            break;
                        case 4:
                            Console.WriteLine($"{playerName} so far you have 500 $ but they are not guaranteed until you succesfully answer the 5th question!");
                            break;
                        case 5:
                            Console.WriteLine($"{playerName} so far you have 1000 $ guaranteed!");
                            break;
                        case 6:
                            Console.WriteLine($"{playerName} so far you have 2000 $ but only 1000 $ are guaranteed until you succesfully answer the 10th question!");
                            break;
                        case 7:
                            Console.WriteLine($"{playerName} so far you have 4000 $ but only 1000 $ are guaranteed until you succesfully answer the 10th question!");
                            break;
                        case 8:
                            Console.WriteLine($"{playerName} so far you have 8000 $ but only 1000 $ are guaranteed until you succesfully answer the 10th question!");
                            break;
                        case 9:
                            Console.WriteLine($"{playerName} so far you have 16 000 $ but only 1000 $ are guaranteed until you succesfully answer the 10th question!");
                            break;
                        case 10:
                            Console.WriteLine($"{playerName} so far you have 32 000 $ guaranteed!");
                            break;
                        case 11:
                            Console.WriteLine($"{playerName} so far you have 64 000 $ but only 32 000 $ are guaranteed until you succesfully answer question for Million!");
                            break;
                        case 12:
                            Console.WriteLine($"{playerName} so far you have 125 000 $ but only 32 000 $ are guaranteed until you succesfully answer question for Million!");
                            break;
                        case 13:
                            Console.WriteLine($"{playerName} so far you have 250 000 $ but only 32 000 $ are guaranteed until you succesfully answer question for Million!");
                            break;
                        case 14:
                            Console.WriteLine($"{playerName} so far you have 500 000 $ but only 32 000 $ are guaranteed until you succesfully answer question for Million!");
                            break;
                        case 15:
                            Console.WriteLine($"{playerName} Hoooraaayy you won the Million!!!! You are the new Millioner! Congratulations");
                            break;
                    }

                }
                while (true)
                {
                    Console.WriteLine("Please press ENTER to continue!");
                    if (Console.ReadLine() == "") break;
                }
            }
        }
    }
}
