using System;
using Taks1ClassLibrary.Models;
using Taks1ClassLibrary.Enums;
using System.Collections.Generic;
using System.Linq;



namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
          
            List<Dog> alldogs = new List<Dog>()
            {
                    new Dog("Sharko",2,AnimalColor.Grey,Race.Streeter),
                    new Dog("Sparky",4,AnimalColor.Yellow,Race.Labrador),
                    new Dog("Jonny",3,AnimalColor.Black,Race.BullDog)
            };
            List<Cat> allcats = new List<Cat>()
            {
                    new Cat("Goce",5,AnimalColor.Yellow,true),
                     new Cat("Dimche",1,AnimalColor.Grey,false),
                    new Cat("Blazo",2,AnimalColor.White,true)
            };
            List<Bird> allbidrs = new List<Bird>()
            {
                     new Bird("Sime",5,AnimalColor.White,true),
                     new Bird("Dragi",2,AnimalColor.Grey,true),
                     new Bird("Leta",1,AnimalColor.White,false)
            };
            List<Dog> wantedBullDogs = alldogs.Where(x => x.DogType == Race.BullDog).ToList();
            Cat lastLazyCat = allcats.Where(x => x.IsLazy == true).LastOrDefault();
            List<Bird> allBirdsOlderThan3AndOrderedByName = allbidrs.Where(x => x.Age > 3).OrderBy(x => x.Name).ToList();
        }
    }
}
