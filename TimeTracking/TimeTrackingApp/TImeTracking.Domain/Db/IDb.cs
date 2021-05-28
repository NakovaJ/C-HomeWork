using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TImeTracking.Domain.Core.Entities;

namespace TImeTracking.Domain.Db
{
   public interface IDb<T> where T: BaseEntity
    {
        List<T> GetAll();
        void Insert(T entity);
        void RemoveById(T entity);
        void Update(T entity);
        T GetById(int id);
       
    }
}