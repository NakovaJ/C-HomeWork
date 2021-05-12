using System;
using System.Collections.Generic;
using System.Text;
using TImeTracking.Domain.Core.Interfaces;

namespace TImeTracking.Domain.Core.Entities
{
    public class User :BaseEntity,IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
        List<Activity> Activities { get; set; }
        public override void Print()
        {
            Console.WriteLine($"{FirstName} {LastName} with username {Username} and ID:{Id}");
        }
    }
}
