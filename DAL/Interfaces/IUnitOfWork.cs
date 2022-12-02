using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        ICRUD<Group> Groups { get; }
        ICRUD<Result> Results { get; }
        ICRUD<Test> Tests { get; }
        ICRUD<User> Users { get; }
        ICRUD<GroupUser> GroupUsers { get; }
        ICRUD<UserTest> UserTests { get; }
        void Save();
    }

}
