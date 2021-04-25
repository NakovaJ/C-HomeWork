using System;
using System.Collections.Generic;
using System.Text;

namespace QuizzClassLibrary.Entities.Models
{
    public abstract class User
    {
        public string FirstName { get; set; }
       public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
       
        public User()
        {

        }
        public User(string name,string lastName,string userName, string password)
        {
            FirstName = name;
            LastName = lastName;
            UserName = userName;
            Password = password;
        }
        public abstract void GreetUser();
    }
}
