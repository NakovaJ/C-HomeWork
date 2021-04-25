using System;
using System.Collections.Generic;
using System.Text;
using QuizzClassLibrary.Entities.Models;

namespace QuizzServices
{
    public static class QuizzService
    {
        #region Login
        public static User LoginPage(List <User> allExistingUsers) {
            int counterOfLoginTimes = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Dear user welcome to the QuizzApp!");
                Console.WriteLine();
                Console.WriteLine("To login please enter your username first!");
                string inputUserName = Console.ReadLine();
                Console.WriteLine("Please enter you password!");
                string inputPassword = Console.ReadLine();

                foreach (User user in allExistingUsers)
                {
                    if (user.UserName == inputUserName && user.Password == inputPassword) return user;
                }
                counterOfLoginTimes++;
                if (counterOfLoginTimes == 3) return null;
            }
               
            
           
        }
        #endregion

        #region TakeTest

        public static int TakeQuizz()
        {
            int correctAnswersCounter = 0;
            while (true)
            {
              
                Console.WriteLine();
               
                Console.WriteLine("If you are fully ready to start press enter!");
                if (Console.ReadLine() != "") continue;
                Console.WriteLine();
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("What is the capital of Tasmania?");
                    Console.WriteLine("1 ----> Dodoma");
                    Console.WriteLine("2 ----> Launceston");
                    Console.WriteLine("3 ----> Hobart");
                    Console.WriteLine("4 ----> Wellington");
                    string userAnswer = Console.ReadLine();
                    if (userAnswer != "1" && userAnswer != "2" && userAnswer != "3" && userAnswer != "4") continue;
                    else
                    {
                        if (userAnswer == "3") correctAnswersCounter++;
                        break;
                    }
                }
               
                
                Console.WriteLine();
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("What is the tallest building in the Republic of the Congo?");
                    Console.WriteLine("1 ----> Kinshasa Democratic Republic of the Congo Temple");
                    Console.WriteLine("2 ----> Palais de la Nation");
                    Console.WriteLine("3 ----> Kongo Trade Centre");
                    Console.WriteLine("4 ----> Nabemba Tower");
                    string userAnswer = Console.ReadLine();
                    if (userAnswer != "1" && userAnswer != "2" && userAnswer != "3" && userAnswer != "4") continue;
                    else
                    {
                        if (userAnswer == "4") correctAnswersCounter++;

                        break;
                    }
                }
               
                Console.WriteLine();
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Which of these is not one of Pluto's moons?");
                    Console.WriteLine("1 ----> Styx");
                    Console.WriteLine("2 ----> Hydra");
                    Console.WriteLine("3 ----> Nix");
                    Console.WriteLine("4 ----> Lugia");
                    string userAnswer = Console.ReadLine();
                    if (userAnswer != "1" && userAnswer != "2" && userAnswer != "3" && userAnswer != "4") continue;
                    else
                    {
                        if (userAnswer == "3") correctAnswersCounter++;


                        break;
                    }
                }
                
                Console.WriteLine();
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("What is the smallest lake in the world ? ");
                    Console.WriteLine("1 ----> Onega Lake");
                    Console.WriteLine("2 ----> Benxi Lake ");
                    Console.WriteLine("3 ----> Kivu Lake");
                    Console.WriteLine("4 ----> Wakatipu Lake");
                    string userAnswer = Console.ReadLine();
                    if (userAnswer != "1" && userAnswer != "2" && userAnswer != "3" && userAnswer != "4") continue;
                    else
                    {
                        if (userAnswer == "2") correctAnswersCounter++;
                        break;
                    }
                }
              
                Console.WriteLine();

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("What country has the largest population of alpacas? ");
                    Console.WriteLine("1 ----> Chad");
                    Console.WriteLine("2 ----> Peru ");
                    Console.WriteLine("3 ----> Australia");
                    Console.WriteLine("4 ----> Niger");
                    string userAnswer = Console.ReadLine();
                    if (userAnswer != "1" && userAnswer != "2" && userAnswer != "3" && userAnswer != "4") continue;
                    else
                    {
                        if (userAnswer == "2") correctAnswersCounter++;
                        break;
                    }
                }
        
                Console.WriteLine();
                Console.WriteLine("Thank you for taking the quizz!");
                Console.WriteLine($"You answered {correctAnswersCounter} questions correctly!");
                
                return correctAnswersCounter;
            }
           
        }

        #endregion
    }
}
