using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        public UserService(IUnitOfWork work)
        {
            unitOfWork = work;
        }
        public UserService() : this(new UnitOfWork()) { }
        public bool Add(User user)
        {
            bool added;
            try
            {
                unitOfWork.Users.Add(user);
                unitOfWork.Save();
                added = true;
            }
            catch { added = false; }
            return added;
        }

        public bool DeleteUserFromGroup(User user,Group group)
        {
            bool deleted;
            try
            {
                var groupusers = unitOfWork.GroupUsers.Find(x => x.GroupId == group.Id && x.UserId == user.Id);
                if (groupusers == null) return false;
                foreach(var groupuser in groupusers)
                {
                    unitOfWork.GroupUsers.Delete(groupuser.Id);
                }
                deleted = true;
            }
            catch { deleted = false; }
            return deleted;
        }
        public bool AddUserToGroup(User user, Group group)
        {
            bool added;
            try
            {
                var groupuser = new GroupUser()
                {
                    GroupId = group.Id,
                    UserId = user.Id
                };
                unitOfWork.GroupUsers.Add(groupuser);
                unitOfWork.Save();

                added = true;
            }
            catch { added = false; }
            return added;
        }

        public bool AsignTestToUser(User user, Test test)
        {
            bool added;
            try
            {
                var testuser = new UserTest()
                {
                    TestId = test.Id,
                    UserId = user.Id
                };
                unitOfWork.UserTests.Add(testuser);
                unitOfWork.Save();

                added = true;
            }
            catch { added = false; }
            return added;
        }

        public User AuthenticateAdmin(String login, String password)
        {
            try
            {
                return unitOfWork.Users.Find(x => x.Login == login && x.Password == password && x.IsAdmin).FirstOrDefault();
            }
            catch { }
            return null;
        }

        public User AuthenticateUser(String login, String password)
        {
            try
            {
                return unitOfWork.Users.Find(x => x.Login == login && x.Password == password).FirstOrDefault();
            }
            catch { }
            return null;
        }

        public bool DeleteUser(int id)
        {
            bool deleted;
            try
            {
                unitOfWork.Users.Delete(id);
                unitOfWork.Save();
                deleted = true;
            }
            catch { deleted = false; }
            return deleted;
        }

        public List<User> GetAll()
        {
            try
            {
                return unitOfWork.Users.GetAll().ToList();
            }
            catch { }
            return null;
        }

        public User GetById(int id)
        {
            try
            {
                return unitOfWork.Users.Get(id);
            }
            catch { }
            return null;
        }

        public bool UpdateUser(User user)
        {
            bool updated;
            try
            {
                unitOfWork.Users.Update(user);
                unitOfWork.Save();
                updated = true;
            }
            catch { updated = false; }
            return updated;
        }

        public List<Test> GetAssignedTests(User user)
        {
            var user1 = unitOfWork.Users.Get(user.Id);
            var testIds = user1.UserTests?.Select(x => x.TestId).Distinct().ToList();
            var tests = new List<Test>();
            foreach(var id in testIds)
            {
                var test = unitOfWork.Tests.Get(id);
                if (test != null) tests.Add(test);
            }
            return tests;
        }
    } 
}
