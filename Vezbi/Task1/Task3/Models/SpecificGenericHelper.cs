using System;
using System.Collections.Generic;
using System.Text;
using Taks1ClassLibrary.Models;

namespace Task3
{
    public static class SpecificGenericHelper <T> where T:Animal
    {
        public static void PrintAnimals(List<T> items)
        {
            foreach (T item in items)
            {
                item.Print();
            }
        }
    }
}
