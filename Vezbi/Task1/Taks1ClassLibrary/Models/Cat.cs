using System;
using System.Collections.Generic;
using System.Text;
using Taks1ClassLibrary.Enums;

namespace Taks1ClassLibrary.Models
{
    public class Cat : Animal
    {
        public bool IsLazy { get; set; }
        public Cat() { }
        public Cat(string name, int age, AnimalColor color,bool isLazy):base(name, age, color)
        {
            IsLazy = isLazy;
        }
        public void Meow()
        {
            Console.WriteLine(" MEOW, MEOW, MEOW!");
        }
        public override void Print()
        {
            Console.WriteLine($"The cat is called {Name}, has {Color} and is {Age} years old");
            if (IsLazy) { Console.WriteLine("btw it is a very lazy cat!"); }
            else Console.WriteLine("btw this is not a lazy cat!");

        }
    }
}
