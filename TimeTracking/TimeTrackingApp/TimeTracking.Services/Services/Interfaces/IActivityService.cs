using System;
using System.Collections.Generic;
using System.Text;
using TImeTracking.Domain.Core.Entities;

namespace TimeTracking.Services.Interfaces
{
    public interface IActivityService<T> where T:Activity
    {
        List<T> GetActivities();
        void AddActivity(T activity);
    }
}
