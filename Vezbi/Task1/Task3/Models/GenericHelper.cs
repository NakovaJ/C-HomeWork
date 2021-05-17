using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public static class GenericHelper <T>
    {
        public static void PrintAll(List<T> items)
        {
            foreach(T item in items)
            {
                Console.WriteLine(item);
            }
        }

    }
}
