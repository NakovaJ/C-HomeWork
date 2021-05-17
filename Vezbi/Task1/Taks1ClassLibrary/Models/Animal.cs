using System;
using System.Collections.Generic;
using System.Text;
using Taks1ClassLibrary.Enums;

namespace Taks1ClassLibrary.Models
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public AnimalColor Color { get; set; }

        public Animal() { }
        public Animal (string name, int age,AnimalColor color)
        {
            Name = name;
            Age = age;
            Color = color;
        }
        public abstract void Print();
       

    }
}
