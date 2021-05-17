using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;



namespace Task2.Models
{
    public static class Helper
    {
        public static char GetFirstLetter(this string str)
        {
            if (str.Length == 0) throw new ArgumentException("word must contain letters");
            return str[0];
             
        }

        public static char GetLastLetter(this string str)
        {
            if (str.Length == 0) throw new ArgumentException("word must contain letters");
            return str[str.Length-1];
        }
        //IsEven - Method on Int that checks if its even and returns bool
        public static bool IsEven(this int number)
        {
            if (number < 1) throw new ArgumentException("number should be greater than 0)");
            if (number % 2 == 0) { return true; }
            else { return false; }
        }
      
        public static List<T> GetNfromList(this List<T> list, int number)
        {
            if (number > list.Count()) { throw new ArgumentException("number exceeding the list count)"); }
            else 
            {
                return list.Take(number).ToList();
            }
        }
    }
}
