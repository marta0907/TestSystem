using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    class UserGroupRepository : ICRUD<GroupUser>
    {
        private readonly TSDBContext tSDBContext;
        public UserGroupRepository(TSDBContext context)
        {
            tSDBContext = context;
        }
        public void Add(GroupUser item)
        {
            tSDBContext.GroupUsers.Add(item);
        }

        public void Delete(int id)
        {
            var item = Get(id);
            tSDBContext.GroupUsers.Remove(item);
        }

        public IEnumerable<GroupUser> Find(Func<GroupUser, bool> predicate)
        {
            return tSDBContext.GroupUsers.Where(predicate).AsEnumerable();
        }

        public GroupUser Get(int id)
        {
            return tSDBContext.GroupUsers.Include(x=>x.User).Include(x=>x.Group).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<GroupUser> GetAll()
        {
            return tSDBContext.GroupUsers.Include(x => x.User).Include(x => x.Group).AsEnumerable();
        }

        public void Update(GroupUser item)
        {
            tSDBContext.Entry(item).State = EntityState.Modified;
        }
    }
}
