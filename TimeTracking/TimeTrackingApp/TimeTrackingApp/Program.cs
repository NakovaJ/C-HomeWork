using System;

namespace TimeTrackingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime someDate = DateTime.Now;
            DateTime nextDate;
            while (true)
            {
                if (Console.ReadLine() == "")
                {
                    nextDate = DateTime.Now;
                    break;
                }
            }
            Console.WriteLine(someDate-nextDate);
            
        }
    }
}
