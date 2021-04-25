using System;
using System.Collections.Generic;
using System.Text;
using QuizzClassLibrary.Entities.Interfaces;

namespace QuizzClassLibrary.Entities.Models
{
    public class Teacher : User,ITeacher
    {
        public Teacher(string name, string lastName, string userName, string password)
               :base(name,lastName,userName,password)
        {

        }
        public void DisplayAllStudents(List<User> users)
        {
            foreach(User user in users)
            {
                if(user is IStudent)
                {
                    Student student = (Student)user;
                    if (student.HadTestAlready == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{student.FirstName} {student.LastName} ---- TEST RESULT:{student.TestResult}");
                        Console.ResetColor();
                    }
                    if(student.HadTestAlready==false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{student.FirstName} {student.LastName} -------did not take the test yet!");
                        Console.ResetColor();
                    }
                }
              
            }
        }

     

        public override void GreetUser()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"{FirstName} welcome to the QuizzApp!");
            Console.WriteLine();
            Console.WriteLine("These are all the students asigned to this quizz:");
            Console.WriteLine("The students who already took the test are shown, with the test points, in green! ");
            Console.WriteLine("The students who haven't taken the test yet are shown in red! ");
            Console.WriteLine();
        }
    }
}
