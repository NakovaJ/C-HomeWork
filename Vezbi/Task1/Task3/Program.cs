using System;
using System.Collections.Generic;
using Taks1ClassLibrary.Models;
using Taks1ClassLibrary.Enums;



namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            //3) Create generic methods:
            //PrintList - Method that prints any list of items in the console(strings, bools ints etc. )
            //PrintAnimals - Method that prints any list with Animals(print method) in the console(Dog, Cat Bird and any Animal )
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
            GenericHelper<int>.PrintAll(numbers);
            List<Cat> allcats = new List<Cat>()
            {
                    new Cat("Goce",5,AnimalColor.Yellow,true),
                     new Cat("Dimche",1,AnimalColor.Grey,false),
                    new Cat("Blazo",2,AnimalColor.White,true)
            };
            SpecificGenericHelper<Cat>.PrintAnimals(allcats);
   
            
            
        }
    }
}
