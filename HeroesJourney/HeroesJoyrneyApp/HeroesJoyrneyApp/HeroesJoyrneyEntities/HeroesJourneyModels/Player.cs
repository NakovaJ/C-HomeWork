using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesJoyrneyApp.HeroesJoyrneyEntities.HeroesJourneyModels
{
     public class Player
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string Type { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
       
        public Player()
        {

        }
        public Player(string email, string password,string name)
        {
            Email = email;
            Password = password;
            Name = name;
            Race = "";
            Health = 0;
            Strength = 0;
            Agility = 0;
        }
        public void CreateDwarf()
        {
            Health += 100;
            Strength += 6;
            Agility += 2;
            Race = "Dwarf";
        }
        public void CreateElf()
        {
            Health += 60;
            Strength += 4;
            Agility += 6;
            Race = "Elf";
        }
        public void CreateHuman()
        {
            Health += 80;
            Strength += 5;
            Agility += 4;
            Race = "Human";
        }
        public void BecomeWarrior()
        {
            Health += 20;
            Agility -= 1;
            Type = "Warrior";
        }
        public void BecomeRogue()
        {
            Health -= 20;
            Agility += 1;
            Type = "Rogue";
        }
        public void BecomeMage()
        {
            Health += 20;
            Strength -= 1;
            Type = "Mage";
        }
        public void PrintInfo()
        {
            Console.WriteLine($"{Name} ({Race}) the {Type}");
            Console.WriteLine($"Health:{Health}, Strength:{Strength}, Agility: {Agility}");
        }

    }
}
