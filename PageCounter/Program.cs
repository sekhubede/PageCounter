using PageCounter.ConsoleUtils;
using System;
using System.IO;
using System.Text.RegularExpressions;
using UglyToad.PdfPig;

namespace PageCounter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileManager fileManager = new FileManager();

            try
            {
                fileManager.Start();
            }
            catch (Exception ex)
            {
                FileOperations.LogError(ex);
                throw;
            }
        }
        
    }
}
