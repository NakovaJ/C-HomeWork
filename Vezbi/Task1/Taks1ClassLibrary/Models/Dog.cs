using System;
using System.Collections.Generic;
using System.Text;
using Taks1ClassLibrary.Enums;
namespace Taks1ClassLibrary.Models
{
    public class Dog:Animal
    {
        public Race DogType { get; set; }
        public Dog() { }
        public Dog (string name, int age,AnimalColor color, Race dogtype) : base(name, age,color)
        {
            DogType = dogtype;
        }

        public void Bark()
        {
            Console.WriteLine("BARK BARK!");
        }

        public override void Print()
        {
            Console.WriteLine($"The dog is called {Name}, has {Color} and is {Age} years old!");
            Console.WriteLine($"{Name} is a {DogType}!");
        }
    }
}
