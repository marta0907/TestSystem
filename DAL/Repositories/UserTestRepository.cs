using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    class UserTestRepository : ICRUD<UserTest>
    {
        private readonly TSDBContext tSDBContext;
        public UserTestRepository(TSDBContext context)
        {
            tSDBContext = context;
        }
        public void Add(UserTest item)
        {
            tSDBContext.UserTests.Add(item);
        }

        public void Delete(int id)
        {
            var item = Get(id);
            tSDBContext.UserTests.Remove(item);
        }

        public IEnumerable<UserTest> Find(Func<UserTest, bool> predicate)
        {
            return tSDBContext.UserTests.Where(predicate).AsEnumerable();
        }

        public UserTest Get(int id)
        {
            return tSDBContext.UserTests.Include(x => x.User).Include(x => x.Test).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<UserTest> GetAll()
        {
            return tSDBContext.UserTests.Include(x => x.User).Include(x => x.Test).AsEnumerable();
        }

        public void Update(UserTest item)
        {
            tSDBContext.Entry(item).State = EntityState.Modified;
        }
    }
}
