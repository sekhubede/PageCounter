using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UglyToad.PdfPig;

namespace PageCounter.ConsoleUtils
{
    internal class FileOperations
    {
        private static string ErrorLogPath = @"C:\MFErrorLog";

        /// <summary>
        /// Returns a FileInfo[] object of the files in the specified location if the directory exists.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="DirectoryNotFoundException"></exception>
        public static FileInfo[] GetFiles(string path)
        {
            DirectoryInfo directoryInfo = DirectoryOperations.CreateDirectory(path);

            if (false == directoryInfo.Exists)
            {
                throw new DirectoryNotFoundException($"Path not found '{path}'.");
            }

            return directoryInfo.GetFiles();
        }

        public static int GetNumberOfPages(string filePath)
        {
            PdfDocument document = PdfDocument.Open(filePath);
            int pages = document.NumberOfPages;
            document.Dispose();

            return pages;
        }

        public static void LogError(Exception exception)
        {
            // Create directory for the error log file
            DirectoryInfo TempDirectory = DirectoryOperations.CreateDirectory(ErrorLogPath);

            string fullPath = $@"{ErrorLogPath}\ErrorLog.txt";

            File.Create(fullPath).Close();

            File.WriteAllText(fullPath, $@"{exception.Message}
{exception.StackTrace}");

        }
    }
}
