using System;
using System.Collections.Generic;
using System.Text;
using Taks1ClassLibrary.Enums;

namespace Taks1ClassLibrary.Models
{
    public class Bird:Animal
    {
        bool IsWild { get; set; }
        public Bird() { }
        public Bird(string name, int age, AnimalColor color,bool isWild) : base(name, age, color)
        {
            IsWild = isWild;
        }

        public void FlySouth()
        {
            if (IsWild) { Console.WriteLine("This bird flys south!"); }
            else Console.WriteLine("This bird is domesticated!");
        }

        public override void Print()
        {
            Console.WriteLine($"The bird is called {Name}, has {Color} color and is {Age} years old");

        }
    }
}
