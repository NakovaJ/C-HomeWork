using System;
using System.Collections.Generic;
using System.Text;

namespace Tas2WithMoreInputs.Task2ServiceFolder2
{
   public static class ServiceClass
    {
        public static void SwitchSomeDays(DateTime someDate)
        {
            switch (someDate.DayOfWeek)
            {
                case DayOfWeek.Monday:
                case DayOfWeek.Tuesday:
                case DayOfWeek.Wednesday:
                case DayOfWeek.Thursday:
                case DayOfWeek.Friday:
                    Console.WriteLine($"{someDate} is a working day!");
                    break;
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    Console.WriteLine($"{someDate} is not a working day!");
                    break;
            }
        }

        public static void CheckDate(string input)
        {
            bool successfulParssing = DateTime.TryParse(input, out DateTime userDate);
            if (successfulParssing)
            {
                switch (userDate.Month)
                {
                    case 1:
                        if (userDate.Day == 1 || userDate.Day == 7) Console.WriteLine($"{userDate} is not a working day!");
                        else ServiceClass.SwitchSomeDays(userDate);
                        break;
                    case 4:
                        if (userDate.Day == 20) Console.WriteLine($"{userDate} is not a working day!");
                        else ServiceClass.SwitchSomeDays(userDate);
                        break;
                    case 5:
                        if (userDate.Day == 1 || userDate.Day == 25) Console.WriteLine($"{userDate} is not a working day!");
                        else ServiceClass.SwitchSomeDays(userDate);
                        break;
                    case 8:
                        if (userDate.Day == 3) Console.WriteLine($"{userDate} is not a working day!");
                        else ServiceClass.SwitchSomeDays(userDate);
                        break;
                    case 9:
                        if (userDate.Day == 8) Console.WriteLine($"{userDate} is not a working day!");
                        else ServiceClass.SwitchSomeDays(userDate);
                        break;
                    case 10:
                        if (userDate.Day == 12 || userDate.Day == 23) Console.WriteLine($"{userDate} is not a working day!");
                        else ServiceClass.SwitchSomeDays(userDate);
                        break;
                    case 12:
                        if (userDate.Day == 8) Console.WriteLine($"{userDate} is not a working day!");
                        else ServiceClass.SwitchSomeDays(userDate);
                        break;
                    case 2:
                    case 3:
                    case 6:
                    case 7:
                    case 11:
                        ServiceClass.SwitchSomeDays(userDate);
                        break;
                }
               
            }
            else
            {
                Console.WriteLine("Date in not in the appropriate format!");
            }
        }

       
    }
}
