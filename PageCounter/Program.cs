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
            Temp fileManager = new Temp();
            fileManager.Start();
        }
        
    }

    internal class Temp
    {
        public void Start()
        {

            using (PdfDocument document = PdfDocument.Open(@"C:\PageCount\15266881-460 2-539815-549 (ID 1847614).pdf"))
            {
                int pageCount = document.NumberOfPages;

                Console.WriteLine(pageCount);
            }


            Console.ReadKey(true);
        }
    }
}
