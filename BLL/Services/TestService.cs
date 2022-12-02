using BLL.Interfaces;
using BLL.Managers;
using DAL.Entities;
using DAL.Interfaces;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TestService : ITestService
    {
        private readonly IFileSystemManager fileSystemManager;
        private readonly ISerializationManager<Test> serializationManager;
        private readonly IUnitOfWork unitOfWork;
        private  string testsFolder = "Data";

        public TestService(ISerializationManager<Test> manager, IFileSystemManager manager1, IUnitOfWork work)
        {
            fileSystemManager = manager1;
            serializationManager = manager;
            unitOfWork = work;
        }

        public TestService(): this(new JsonSerializationManager<Test>(), new FileSystemManager(), new UnitOfWork()){ }


        public bool SaveTestToDatabase(Test test)
        {
            bool saved;
            try
            {
                unitOfWork.Tests.Add(test);
                unitOfWork.Save();
                saved = true;
            }
            catch (Exception ex) { saved = false; }
            return saved;
        }

        public IEnumerable<Test> GetAllTestsFromDatabase()
        {
            try
            {
                return unitOfWork.Tests.GetAll();
            }
            catch (Exception ex) { }
            return null;
        }

        public Test GetTestByIdFromDatabase(int id)
        {
            try
            {
                return unitOfWork.Tests.Get(id);
            }
            catch (Exception ex) { }
            return null;
        }

        public async Task<Test> LoadTestFromFileSystem(string path)
        {
            var fullPath = GetFullPath(path);

            var file = await fileSystemManager.ReadFromFileAsync(fullPath);

            if (file == null) return null;

            return serializationManager.Deserialize(file);
        }


        public async Task<bool> SaveTestToFileSystem(Test test)
        {
            var fullPath = GetFullPath(test.testPath);

            var json = serializationManager.Serialize(test);

            if (json == null) return false;
            else
                return await fileSystemManager.WriteToFileAsync(json, fullPath);

        }

        private string GetFullPath(string path)
        {
            var rootDirectory = fileSystemManager.GetProjectRootPath();

            var rootPath = rootDirectory is null ?
                fileSystemManager.GetCurrentDirectory() : rootDirectory.FullName;
            
            var result= fileSystemManager.Combine(rootPath, testsFolder, path);
            return result;
        }

        public int MaxPoints(Test test)
        {
            int maxPoints = 0;
            test.Questions.ToList().ForEach(x => maxPoints += x.NumOfPoints);
            return maxPoints;
        }
    }
}
