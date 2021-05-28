using System;
using System.Collections.Generic;
using System.Text;
using TImeTracking.Domain.Core.Entities;

namespace TimeTracking.Services.Interfaces
{
    public interface IUserService<T> where T:BaseEntity
    {
        T Login(string username, string password);
        T Register(T user);
        bool IsDbEmpty();
        public List<T> CheckAllUsers();
        public void DeActivateAcount(T user);
        public void ChangePassword(User user, string oldPassword, string newPassword);
        public void ChangeInfo(User user, string firstName, string lastName);


    }
}
