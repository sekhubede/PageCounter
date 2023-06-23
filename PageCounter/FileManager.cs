using PageCounter.ConsoleUtils;
using System;
using System.Diagnostics;
using System.IO;

namespace PageCounter
{
    public class FileManager
    {
        private string ApplicationTitleArt = @"

██████   █████   ██████  ███████      ██████  ██████  ██    ██ ███    ██ ████████ ███████ ██████  
██   ██ ██   ██ ██       ██          ██      ██    ██ ██    ██ ████   ██    ██    ██      ██   ██ 
██████  ███████ ██   ███ █████       ██      ██    ██ ██    ██ ██ ██  ██    ██    █████   ██████  
██      ██   ██ ██    ██ ██          ██      ██    ██ ██    ██ ██  ██ ██    ██    ██      ██   ██ 
██      ██   ██  ██████  ███████      ██████  ██████   ██████  ██   ████    ██    ███████ ██   ██ 
";
        private string Description = "A pdf file page counter that appends the count to the name of the pdf :)";
        private string ApplicationTitle = "PDF Page Counter";

        private string FilePath = @"C:\PageCount";
        private string Extension = ".PDF";

        // Simple constructor
        public FileManager()
        {

        }

        // Entry of the file application, handles all the logic of the application
        public void Start()
        {
            Console.Title = ApplicationTitle;
            Console.WriteLine(ApplicationTitleArt);
            Console.WriteLine(Description);

            WaitForKeyPress();

            // TODO: Prompt the user for the location of the pdf files to rename

            // Cache the files in the location
            try
            {
                FileInfo[] files = FileUtils.GetFiles(FilePath);
                int counter = 1;
                foreach (FileInfo file in files) 
                {
                    if (false == Path.GetFileNameWithoutExtension(file.FullName).Contains("["))
                    {
                        // Get file count
                        int pageCount = FileUtils.GetNumberOfPages(file.FullName);

                        // Get the page count and rename the file
                        string newFileName = $@"{Path.GetFileNameWithoutExtension(file.FullName)} - [{pageCount}]{Path.GetExtension(file.FullName)}";

                        file.MoveTo($@"{FilePath}\{newFileName}");

                        Console.Clear();
                        Console.WriteLine($"Files renamed: {counter++}");
                    }
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("\npress any key to exit.");
                Console.ReadKey(true);
                Environment.Exit(0 );
            }



            WaitForKeyPress();


        }

        // Wait for user to press key before continuinig
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

        // Return the version number from the appliction assembly
        private static string AddVersionNumber()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);

            return $"v.{versionInfo.FileVersion}";
        }


    }
}
