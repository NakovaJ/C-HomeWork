using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeTracking.Services.Helpers;
using TimeTracking.Services.Interfaces;
using TImeTracking.Domain.Core.Entities;
using TImeTracking.Domain.Db;

namespace TimeTracking.Services.Implementation
{
    public class UserService<T> : IUserService<T> where T : User
    {
        private IDb<T> _db;
        public UserService()
        {
            _db = new LocalDb<T>();
        }
        public T Login(string username, string password)
        {
            T user = _db.GetAll()
                  .SingleOrDefault(x => x.Username == username && x.Password == password);
            if (user == null)
            {
                MessageHelper.Color("[Error] Username or password did not match!", ConsoleColor.Red);
                Console.ReadLine();
                return null;
            }
            if (user.ProfileActive == false)
            {
                MessageHelper.Color("[Attention] Your profile is deactivated!", ConsoleColor.Yellow);
                MessageHelper.Color("Press 1 to Activate Your Profile!",ConsoleColor.Yellow);
                MessageHelper.Color("Press any key to go back!", ConsoleColor.Yellow);
                if (Console.ReadLine() == "1")
                {
                    user.ProfileActive = true;
                }
                else return null;

            }
            return user;
        }
        public T Register(T user)
        {
            if (ValidationHelper.ValidateString(user.FirstName,2) == null
                || ValidationHelper.ValidateString(user.LastName,4) == null
                || ValidationHelper.ValidateString(user.Username,5) == null
                || ValidationHelper.ValidatePassword(user.Password) == null)
            {
                MessageHelper.Color("[Error] Invalid Info!", ConsoleColor.Red);
                Console.ReadLine();
                return null;
            }
            _db.Insert(user);
            int id = user.Id;
            return _db.GetById(id);
        }
      
        public bool IsDbEmpty()
        {
            if (_db.GetAll().Count == 0) return true;
            else return false;
        }
        public List<T> CheckAllUsers()
        {
            return _db.GetAll();
        }
        public void DeActivateAcount(T user)
        {
            Console.Clear();
            if (user.ProfileActive == true)
            {
                Console.WriteLine("Your profile is active!");
                while (true)
                {
                    Console.WriteLine("1) To deactivate your account!");
                    Console.WriteLine("2) To go back!");
                    
                    int userChoice = ValidationHelper.ValidateNumber(Console.ReadLine(),0,2);
                    if (userChoice == 2) break;
                    if (userChoice == 1)
                    {
                        user.ProfileActive = false;
                        MessageHelper.Color("[Attention] Your profile has been deacitaved!", ConsoleColor.Red);
                        Console.ReadLine();
                        break;
                    }
                   
                }

            }
            else
            {
                Console.WriteLine("Your profile is deactivated!");

                while (true)
                {
                    Console.WriteLine("1) To activate your account!");
                    Console.WriteLine("2) To go back!");

                    int userChoice = ValidationHelper.ValidateNumber(Console.ReadLine(), 0, 2);
                    if (userChoice == 2) break;
                    if (userChoice == 1)
                    {
                        user.ProfileActive = true;
                        MessageHelper.Color("[Attention] Your profile has been acitaved again!", ConsoleColor.Green);
                        Console.ReadLine();
                        break;
                    }

                }
            }
        }
        public void ChangePassword(User user, string oldPassword, string newPassword)
        {
            
            if (user.Password != oldPassword)
            {
                MessageHelper.Color("[Error] Old password did not match", ConsoleColor.Red);
                Console.ReadLine();
                return;
            }
            if (ValidationHelper.ValidatePassword(newPassword) == null)
            {
                MessageHelper.Color("[Error] New password is not valid", ConsoleColor.Red);
                Console.ReadLine();
                return;
            }
            user.Password = newPassword;
            _db.Update((T)user);
            MessageHelper.Color("Password successfully changed!", ConsoleColor.Green);
            Console.ReadLine();
        }

        public void ChangeInfo(User user, string firstName, string lastName)
        {
            
            if (ValidationHelper.ValidateString(firstName,5) == null || ValidationHelper.ValidateString(lastName,6) == null)
            {
                MessageHelper.Color("[Error] strings were not valid. Please try again!", ConsoleColor.Red);
                Console.ReadLine();
                return;
            }
            user.FirstName = firstName;
            user.LastName = lastName;
            _db.Update((T)user);
            MessageHelper.Color("Data successfuly changed!", ConsoleColor.Green);
            Console.ReadLine();
        }

    }
}
