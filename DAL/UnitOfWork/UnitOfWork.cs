using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;


namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private  GroupRepository groupRepository;
        private  ResultRepository resultRepository;
        private  TestRepository testRepository;
        private  UserRepository userRepository;
        private UserGroupRepository userGroupRepository;
        private UserTestRepository userTestRepository;
        private TSDBContext tSDBContext;
        public UnitOfWork()
        {
            tSDBContext = new TSDBContext();
        }

        public ICRUD<Group> Groups
        {
            get
            {
                if (groupRepository == null)
                    groupRepository = new GroupRepository(tSDBContext);
                return groupRepository;
            }
        }


        public ICRUD<Result> Results
        {
            get
            {
                if (resultRepository == null)
                    resultRepository = new ResultRepository(tSDBContext);
                return resultRepository;
            }
        }

        public ICRUD<Test> Tests
        {
            get
            {
                if (testRepository == null)
                    testRepository = new TestRepository(tSDBContext);
                return testRepository;
            }
        }

        public ICRUD<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(tSDBContext);
                return userRepository;
            }
        }

        public ICRUD<GroupUser> GroupUsers
        {
            get
            {
                if (userGroupRepository == null)
                    userGroupRepository = new UserGroupRepository(tSDBContext);
                return userGroupRepository;
            }
        }

        public ICRUD<UserTest> UserTests
        {
            get
            {
                if (userTestRepository == null)
                    userTestRepository = new UserTestRepository(tSDBContext);
                return userTestRepository;
            }
        }

        public void Save()
        {
            tSDBContext.SaveChanges();
        }
    }
}
