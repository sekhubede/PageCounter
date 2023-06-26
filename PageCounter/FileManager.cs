using Figgle;
using PageCounter.ConsoleUtils;
using System;
using System.Diagnostics;
using System.IO;

namespace PageCounter
{
    public class FileManager
    {
        private string Description = "A pdf file page counter that appends the count to the name of the pdf :)";
        private string ApplicationTitle = "PDF Page Counter";

        private string FilePath = @"C:\MFTemp1";

        // Simple constructor
        public FileManager()
        {

        }

        // Entry of the file application, handles all the logic of the application
        public void Start()
        {
            Console.Title = $"{ApplicationTitle} {AddVersionNumber()}";
            Console.WriteLine(FiggleFonts.Standard.Render(ApplicationTitle));
            Console.WriteLine(Description);

            WaitForKeyPress();

            // TODO: prompt the user for the location of the pdf files to rename

            NotifyUser("(processing...)");

            // Cache the files in the location
            FileInfo[] files = FileOperations.GetFiles(FilePath);

            int counter = 1;

            foreach (FileInfo file in files) 
            {
                if (false == Path.GetFileNameWithoutExtension(file.FullName).Contains("["))
                {
                    // Get file count
                    int pageCount = FileOperations.GetNumberOfPages(file.FullName);

                    // Get the page count and rename the file
                    string newFileName = $@"{Path.GetFileNameWithoutExtension(file.FullName)} - [{pageCount}]{Path.GetExtension(file.FullName)}";

                    file.MoveTo($@"{FilePath}\{newFileName}");

                }
            }

            Console.Clear();
            NotifyUser($"Files Processed: {counter++}");
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey(true);
            Environment.Exit(0);
        }

        private void WaitForKeyPress()
        {
            // Cache the previous color
            ConsoleColor previousColor = Console.ForegroundColor;

            // Change console foreground color
            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine("\n(press any key to continue...)");
            Console.ReadKey(true);

            // Reset the color to what it was
            Console.ForegroundColor = previousColor;
        }

        private void NotifyUser(string message)
        {
            // Cache the previous console foreground color
            ConsoleColor previousColor = Console.ForegroundColor;

            // Change the color foreground color
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"\n{message}");

            // Reset the foreground color back to what it was
            Console.ForegroundColor = previousColor;
        }

        // Return the version number from the appliction assembly
        private static string AddVersionNumber()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);

            return $"v.{versionInfo.FileVersion}";
        }


    }
}
