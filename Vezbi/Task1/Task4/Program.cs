using System;

namespace Task4
{
    
    class Program
    {
        static void Main(string[] args)
        {
            //4) Create a delegate that accepts two strings and returns bool
            // Create a method called StringMagic that requires the delegate as parameter and that executes the delegate and prints the 2 strings and the result
            //Call the StringMagic method to compare 2 strings length
            //Call the StringMagic method to compare if the 2 strings start on the same character
            //Call the StringMagic method to compare if the 2 strings end on the same character
            Func<int, int, bool> firstIsLarger = (x, y) =>
            {
                return x > y;
            };

            Func<string, string, bool> startWithSameCharacter = (x, y) =>
           {
               return x[0] == y[0];
           };
            Func<string, string, bool> endsWithSameCharacter = (x, y) =>
             {
                 return x[x.Length - 1] == y[y.Length - 1];
             };

            

           
        }
    }
}
