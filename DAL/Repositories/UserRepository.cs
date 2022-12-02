using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{

    class UserRepository : ICRUD<User>
    {
        private readonly TSDBContext tSDBContext;
        public UserRepository(TSDBContext context)
        {
            tSDBContext = context;
        }

        public IEnumerable<User> GetAll()
        {
          return tSDBContext.Users.Include(x=>x.GroupUsers).Include(x=>x.UserTests).AsEnumerable();
        }

        public User Get(int id)
        {
            return tSDBContext.Users.Include(x => x.GroupUsers).Include(x => x.UserTests).FirstOrDefault(x=>x.Id==id);
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return tSDBContext.Users.Include(x => x.GroupUsers).Include(x => x.UserTests).Where(predicate);
        }

        public void Add(User item)
        {
           tSDBContext.Users.Add(item);
        }

        public void Update(User item)
        {
          tSDBContext.Entry(item).State= EntityState.Modified;
        }

        public void Delete(int id)
        {
           var user = tSDBContext.Users.FirstOrDefault(x => x.Id == id);
           tSDBContext.Users.Remove(user);
        }
    }
}
