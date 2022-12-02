using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public  interface ICRUD<T> where T : class
    {
        public IEnumerable<T> GetAll();
        public T Get(int id);
        public IEnumerable<T> Find(Func<T, Boolean> predicate);
        public void Add(T item);
        public void Update(T item);
        public void Delete(int id);

    }   
}
