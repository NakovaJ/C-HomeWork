using System;
using System.Collections.Generic;
using System.Text;

namespace Task2.Task2ServiceFolder
{
    public static class SwitchDays
    {
        public static void switchSomeDays(DateTime someDate)
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
    }
}
