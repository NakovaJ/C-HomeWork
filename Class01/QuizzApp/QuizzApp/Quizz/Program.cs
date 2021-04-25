using System;
using System.Collections.Generic;
using QuizzClassLibrary.Entities.Models;
using QuizzClassLibrary.Entities.Interfaces;
using QuizzServices;

namespace Quizz
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Creating Users

            List<User> allUsers = new List<User>()
            {
            new Student("Jelena","Nakova","jelena01","Jelena01"),
            new Student("Martina","Veterovska","martina01","Martina01"),
            new Student("Darko","Boshkovski","darko01","Darko01"),
            new Student("Sanja","Hristov","sanja01","Sanja01"),
            new Student("Nina","Spasikj","nina01","Nina01"),
            new Student("Ivan","Jamandilovski","ivan01","Ivan01"),
            new Student("Ceca","Vasileva","ceca01","Ceca01"),
            new Student("Oliver","Zdravevski","oliver01","Oliver01"),
            new Student("Nikola","Sheskokalov","nikola01","Nikola01"),
            new Student("Jana","Simjanovska","jana01","Jana01"),
            new Teacher("Kristina","Spasevska","kristina01","Kristina01"),
            new Teacher("Pane","Manaskov","pane01","Pane01")

            };

            #endregion

            while (true)
            {
                User userActive = QuizzService.LoginPage(allUsers);
                if (userActive == null) break;
                if(userActive is IStudent)
                {
                    Student studentActive = (Student)userActive;
                    if (studentActive.HadTestAlready == true)
                    {
                        studentActive.StudentAlreadyOnceLoggedIn();
                    }
                    else
                    {
                        studentActive.GreetUser();
                        int points = QuizzService.TakeQuizz();
                        studentActive.QuizzResults(points);
                        studentActive.HadTestAlready = true;
                        while (true)
                        {
                            Console.WriteLine("Press enter to log out!");
                            if (Console.ReadLine() == "") break;
                        }
                        

                    }
                }
                if(userActive is ITeacher)
                {
                    while (true)
                    {
                        Teacher teacherActive = (Teacher)userActive;
                        teacherActive.GreetUser();
                        teacherActive.DisplayAllStudents(allUsers);
                        Console.WriteLine();
                        Console.WriteLine("Press enter ----> to log out!");
                        if (Console.ReadLine() == "") break;
                    }
                 
                }
            }

        }
    }
}
