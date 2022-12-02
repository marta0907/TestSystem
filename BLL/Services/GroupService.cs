using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DAL.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork unitOfWork;
        public GroupService(IUnitOfWork work)
        {
            unitOfWork = work;
        }
        public GroupService() : this(new UnitOfWork()) { }

        public bool Add(Group group)
        {
            bool added;
            try
            {
                unitOfWork.Groups.Add(group);
                unitOfWork.Save();
                added = true;
            }
            catch { added = false; }
            return added;
        }

        public List<Group> GetAll()
        {
            try
            {
                return unitOfWork.Groups.GetAll().ToList();
            }
            catch { }
            return null;
        }

        public bool AsignTestToGroup(Group group, Test test)
        {

            bool added;
            try
            {
                foreach(var groupuser in group.GroupUsers)
                {
                    var testuser = new UserTest()
                    {
                        TestId = test.Id,
                        UserId = groupuser.UserId
                    };
                    unitOfWork.UserTests.Add(testuser);
                    unitOfWork.Save();
                }
                
                added = true;
            }
            catch { added = false; }
            return added;
        }

        public Group GetById(int id)
        {
            try
            {
                return unitOfWork.Groups.Get(id);
            }
            catch { }
            return null;
        }

        public bool UpdateGroup(Group group)
        {
            bool updated;
            try
            {
                unitOfWork.Groups.Update(group);
                unitOfWork.Save();
                updated = true;
            }
            catch { updated = false; }
            return updated;
        }

        public bool DeleteGroup(int id)
        {
            bool deleted;
            try
            {
                unitOfWork.Groups.Delete(id);
                unitOfWork.Save();
                deleted = true;
            }
            catch { deleted = false; }
            return deleted;
        }
    }
}
