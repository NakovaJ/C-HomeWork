using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeTracking.Services.Interfaces;
using TImeTracking.Domain.Core.Entities;
using TImeTracking.Domain.Core.Enums;
using TImeTracking.Domain.Db;

namespace TimeTracking.Services.Implementation
{
    public class ActivityService<T> : IActivityService<T> where T : Activity
    {
        private IDb<T> _db;

        public ActivityService()
        {
            _db = new LocalDb<T>();
        }

        public void AddActivity(T activity)
        {
            _db.Insert(activity);
        }

        public List<T> GetActivities()
        {
           return _db.GetAll();
        }
       
     
    }
}
