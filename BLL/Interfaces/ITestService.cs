using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITestService
    {
        Task<Test> LoadTestFromFileSystem(string path);

        bool SaveTestToDatabase(Test test);

        IEnumerable<Test> GetAllTestsFromDatabase();

        Test GetTestByIdFromDatabase(int id);

        Task<bool> SaveTestToFileSystem(Test test);
    }
}
