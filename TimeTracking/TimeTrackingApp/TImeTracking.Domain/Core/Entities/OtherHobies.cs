using System;
using System.Collections.Generic;
using System.Text;
using TImeTracking.Domain.Core.Interfaces;

namespace TImeTracking.Domain.Core.Entities
{
    public class OtherHobies:Activity,IHobby
    {
        string NameOfHoby { get; set; }

        public void EnterNameOfHobby()
        {
            Console.WriteLine("Please enter a name of the hobby you did!");
            string userInput = Console.ReadLine();
            NameOfHoby = userInput;
        }

        public override void Print()
        {
            Console.WriteLine($"Currently doing other hobbies -- Total hours spent on hobbies {TotalTimeSpentOnActivity} so far!");

        }

    }
}
