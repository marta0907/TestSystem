using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace DAL.Repositories
{
    class GroupRepository : ICRUD<Group>
    {
        private readonly TSDBContext tSDBContext;
        public GroupRepository(TSDBContext context)
        {
            tSDBContext = context;
        }
        public void Add(Group item)
        {
           tSDBContext.Groups.Add(item);
        }

        public void Delete(int id)
        {
            var group = tSDBContext.Groups.FirstOrDefault(x => x.Id == id);
            tSDBContext.Groups.Remove(group);
        }

        public IEnumerable<Group> Find(Func<Group, bool> predicate)
        {
            return tSDBContext.Groups.Include(x => x.GroupUsers).Where(predicate);
        }

        public Group Get(int id)
        {
            return tSDBContext.Groups.Include(x => x.GroupUsers).FirstOrDefault(x=>x.Id==id);
        }

        public IEnumerable<Group> GetAll()
        {
            return tSDBContext.Groups.Include(x => x.GroupUsers).AsEnumerable();
        }

        public void Update(Group item)
        {
            tSDBContext.Entry(item).State = EntityState.Modified;
        }
    }
}
