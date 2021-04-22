using System;
using System.Collections.Generic;
using Tas2WithMoreInputs.Task2ServiceFolder2;

namespace Tas2WithMoreInputs
{
    class Program
    {
        static void Main(string[] args)
        {
            //This is the second task again but with the option for the user to enter more dates at once!
            List<string> userInputDates = new List<string>();

            for(; ; )
            {
                Console.Clear();
                Console.WriteLine("Please enter dates in the following format dd/mm/yyyy!");
                Console.WriteLine("When you entered all the dates you want to check press 'Y' " +
                    "and we will let you know which dates, form the ones you entered are not working days");
                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "y") break;
                userInputDates.Add(userInput);
            }

            try
            {
                userInputDates.ForEach(x =>ServiceClass.CheckDate(x));

            }
            catch(Exception ex)
            {

            }

        }
    }
}
