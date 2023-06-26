using System.IO;

namespace PageCounter.ConsoleUtils
{
    internal class DirectoryOperations
    {
        public static DirectoryInfo CreateDirectory(string path)
        {
            return Directory.CreateDirectory(path);
        }
    }
}
