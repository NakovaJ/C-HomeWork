using DocuSign.eSign.Model;
using System;
using System.Collections.Generic;
using System.Text;
using QuizzClassLibrary.Entities.Models;
using QuizzClassLibrary.Entities.Interfaces;

namespace QuizzClassLibrary.Entities.Models
{
    public class Student : User,IStudent

    {
        public bool HadTestAlready { get; set; }
        public int TestResult { get; set; } = 0;
        public Student()
        {

        }
        public Student(string name, string lastName, string userName, string password)
                      :base(name,lastName,userName,password)
        {
           
        }

       
        public override void GreetUser()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"{FirstName} welcome to the QuizzApp!");
            Console.WriteLine("This Quizz contains 5 questions of multiple choice.");
            Console.WriteLine("Only one of the provided answers is correct!");
            Console.WriteLine("Please consider that you may take the quizz only once so read and answer the questions carefully!");

            Console.WriteLine("Please enter the number of the provided answer you consider correct!");
            Console.WriteLine("Good luck!");
            Console.WriteLine();

        }

        public void StudentAlreadyOnceLoggedIn()
        {
            while (true)
            {
                Console.WriteLine($"{FirstName} you have already taken the test!");
                Console.WriteLine("Please press enter ----> to log out so the next user can log in!");
                if (Console.ReadLine() == "") break;
            }
         
        }

        public void QuizzResults(int result)
        {
            TestResult = result;
        }
    }
}
