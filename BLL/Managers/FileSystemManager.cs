using BLL.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Managers
{
    class FileSystemManager : IFileSystemManager
    {
        public string Combine(params string[] ps)
        {
            return Path.Combine(ps);
        }

        public bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        public string GetCurrentDirectory()
        {
            return Directory.GetCurrentDirectory();
        }

        public DirectoryInfo GetProjectRootPath(string currentPath = null)
        {
            var directory = new DirectoryInfo(
                      currentPath ?? GetCurrentDirectory());
            while (directory != null && !directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }
            return directory;
        }

        public Task<string> ReadFromFileAsync(string filePath)
        {
            try
            {
                return File.ReadAllTextAsync(filePath);
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            return null;
        }

        public async Task<bool> WriteToFileAsync(string str, string filePath)
        {
            try
            {
                await File.WriteAllTextAsync(filePath, str);
                return true;
            }
            catch (Exception e) { Console.WriteLine(e.Message);  }
            return false; 
        }
    }
}
