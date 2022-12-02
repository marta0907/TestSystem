using DAL.Entities;
using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        bool Add(User user);
        List<User> GetAll();
        bool AsignTestToUser(User user, Test test);
        User GetById(int id);
        bool UpdateUser(User user);
        bool DeleteUser(int id);
        bool DeleteUserFromGroup(User user, Group group);
        bool AddUserToGroup(User user, Group group);
        User AuthenticateUser(String login,String password);
        User AuthenticateAdmin(String login, String password);
        public List<Test> GetAssignedTests(User user);
    }
}
