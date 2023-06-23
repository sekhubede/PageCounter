using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PageCounter.ConsoleUtils
{
    internal class FileUtils
    {
        /// <summary>
        /// Returns a FileInfo[] object of the files in the specified location if the directory exists.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="DirectoryNotFoundException"></exception>
        public static FileInfo[] GetFiles(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            if (false == directoryInfo.Exists)
            {
                throw new DirectoryNotFoundException($"Path not found '{path}'.");
            }

            return directoryInfo.GetFiles();
        }

        public static int GetNumberOfPages(string fileName)
        {
            using (StreamReader stream = new StreamReader(File.OpenRead(fileName)))
            {
                Regex regex = new Regex(@"/Type\s*/Page[^s]");
                MatchCollection matches = regex.Matches(stream.ReadToEnd());

                return matches.Count;
            }
        }
    }
}
