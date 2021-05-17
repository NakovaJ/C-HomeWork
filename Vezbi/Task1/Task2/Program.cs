using System;
using Task2.Models;
using System.Collections.Generic;



namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create extension methods:
            //GetFirstLetter - Method on String that returns the first letter of a string
            //LastLetter - Method on String that returns the last letter of a string
            //IsEven - Method on Int that checks if its even and returns bool
            //GetNfromList - Generic method that accepts an int and returns the first N(input ) items from that list

            string one = "one";
            Console.WriteLine(one.GetFirstLetter());
            Console.WriteLine(one.GetLastLetter());
            int number = 3;
            Console.WriteLine(number.IsEven());

        }
    }
}
