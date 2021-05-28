using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TImeTracking.Domain.Core.Entities;


namespace TImeTracking.Domain.Db
{
    public class LocalDb<T> : IDb<T> where T : BaseEntity
    {
        private List<T> db;
        public int IdCount { get; set; }
        public LocalDb()
        {
            db = new List<T>();
            IdCount = 1;
        }

      

        public List<T> GetAll()
        {
            return db;
        }

        public T GetById(int id)
        {
            return db.SingleOrDefault(x => x.Id == id);
        }

        public void Insert(T entity)
        {
            entity.Id = IdCount;
            db.Add(entity);
            IdCount++;
            
        }

        public void RemoveById(T entity)
        {
            T item = db.SingleOrDefault(x => x.Id == entity.Id);
            if(item!=null) db.Remove(item);
        }

        public void Update(T entity)
        {
            T item = db.SingleOrDefault(x => x.Id == entity.Id);
            item = entity;
        }
    }
}
