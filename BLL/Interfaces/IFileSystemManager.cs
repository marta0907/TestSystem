using System.IO;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IFileSystemManager
    {
        public bool FileExists(string filePath);

        public Task<bool> WriteToFileAsync(string str, string filePath);

        public Task<string> ReadFromFileAsync(string filePath);

        public DirectoryInfo GetProjectRootPath(string currentPath = null);
        public string Combine(params string[] ps);

        public string GetCurrentDirectory();
    }
}
