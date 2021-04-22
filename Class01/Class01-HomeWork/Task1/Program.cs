using System;
using System.Collections.Generic;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1.Create a console application that detect provided names in a provided text 🔹
            //The application should ask for names to be entered until the user enteres x
            //After that the application should ask for a text
            //When that is done the application should show how many times
            //that name was included in the text ignoring upper / lower case

            List<string> userEnteredNames = new List<string>();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please enter names in your list!");
                Console.WriteLine("When you are done press x ---> to go out!");

                string userInput = Console.ReadLine();
                if (userInput == "x") break;
                userEnteredNames.Add(userInput);
            }

            Console.WriteLine("Please enter a name you are looking for and we'll tell you how many times you have it in your list!");
            string userSecondInput = Console.ReadLine();
            int counter = 0;
            userEnteredNames.ForEach(x => { if (x == userSecondInput) counter++; });
            Console.WriteLine($"The name {userSecondInput} appears {counter} times in your list!");

        }
    }
}
