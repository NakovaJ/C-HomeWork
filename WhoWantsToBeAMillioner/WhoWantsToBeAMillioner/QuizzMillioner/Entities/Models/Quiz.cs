using System;
using System.Collections.Generic;
using System.Text;

namespace QuizzMillioner.Entities.Models
{
    public abstract class Quiz
    {
        
       public string Name { get; set; }
       public List <List<Question>> Questions { get; set; }
       public Quiz() { }
        public Quiz(string name,List<List<Question>>questions)
        {
            Name = name;
            Questions = questions;
        }

        public abstract void Start();
    }
}
