using DAL.Entities;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IGroupService
    {
        bool Add(Group group);
        List<Group> GetAll();
        bool AsignTestToGroup(Group group, Test test);
        Group GetById(int id);
        bool UpdateGroup(Group group);
        bool DeleteGroup(int id);
    }
}
