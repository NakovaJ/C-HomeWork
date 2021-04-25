using System;
using System.Collections.Generic;
using System.Text;
using QuizzClassLibrary.Entities.Models;

namespace QuizzClassLibrary.Entities.Interfaces
{
    public interface ITeacher
    {
        public void DisplayAllStudents(List<User> students);
    }
}
