using System;
using System.Collections.Generic;
using System.Text;
using TImeTracking.Domain.Core.Entities;


namespace TImeTracking.Domain.Db
{
    public class LocalDb<T> : IDb<T> where T : BaseEntity
    {
        private List<T> db;

        public LocalDb()
        {
            db = new List<T>();
        }
        public List<T> GetAll()
        {
            return db;
        }

        public void Insert(T entity)
        {
            db.Add(entity);
        }

        public void Remove(T entity)
        {
            db.Remove(entity);
        }
    }
}
