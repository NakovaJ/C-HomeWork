using System;
using Task2.Task2ServiceFolder;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            //2.Create a console application that checks if a day is a working day 🔹
            //The app should request for a user to enter a date as an input or multiple inputs
            //The app should then open and see if the day is a working day
            //It should show the user a message whether the date they entered is working or not
            //Weekends are not working
            //1 January, 7 January, 20 April, 1 May, 25 May, 3 August, 8 September, 12 October, 23 October and 8 December are not working days as well
            //It should ask the user if they want to check another date
            //Yes - the app runs again
            //No - the app closes

            for(; ; )
            {
                Console.Clear();
                Console.WriteLine("Please enter a date and check if it is a working day!");
                Console.WriteLine("*** date should be in the following format dd/mm/yyyy ***");
                string userInput = Console.ReadLine();
                bool successfulParssing = DateTime.TryParse(userInput, out DateTime userDate);
                if (successfulParssing)
                {
                    switch (userDate.Month)
                    {
                        case 1:
                            if (userDate.Day == 1 || userDate.Day==7) Console.WriteLine($"{userDate} is not a working day!");
                            else SwitchDays.switchSomeDays(userDate);
                            break;
                        case 4:
                            if (userDate.Day == 20) Console.WriteLine($"{userDate} is not a working day!");
                            else SwitchDays.switchSomeDays(userDate);
                            break;
                        case 5:
                            if (userDate.Day == 1 || userDate.Day == 25) Console.WriteLine($"{userDate} is not a working day!");
                            else SwitchDays.switchSomeDays(userDate);
                            break;
                        case 8:
                            if (userDate.Day == 3) Console.WriteLine($"{userDate} is not a working day!");
                            else SwitchDays.switchSomeDays(userDate);
                            break;
                        case 9:
                            if (userDate.Day == 8) Console.WriteLine($"{userDate} is not a working day!");
                            else SwitchDays.switchSomeDays(userDate);
                            break;
                        case 10:
                            if (userDate.Day == 12 || userDate.Day==23) Console.WriteLine($"{userDate} is not a working day!");
                            else SwitchDays.switchSomeDays(userDate);
                            break;
                        case 12:
                            if (userDate.Day == 8) Console.WriteLine($"{userDate} is not a working day!");
                            else SwitchDays.switchSomeDays(userDate);
                            break;
                        case 2:
                        case 3:
                        case 6:
                        case 7:
                        case 11:
                            SwitchDays.switchSomeDays(userDate);
                         break;
                    }break;

;                }
                else
                {
                    Console.WriteLine("Please enter the date in the appropriate format!");
                }
            }
        }
    }
}
