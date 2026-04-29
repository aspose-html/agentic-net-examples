// Schedule a Windows Task Scheduler job that runs batch validation on all HTML files nightly.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Folder containing HTML files to validate
            string inputFolder = @"C:\HtmlFiles";

            // Scan the folder once for all .html files
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                // Load the HTML document; if loading succeeds the file is considered valid
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    // No additional processing required for validation
                }

                // Report successful validation
                Console.WriteLine($"Validated: {Path.GetFileName(htmlPath)}");
            }
        }
        catch (Exception ex)
        {
            // Report any errors that occur during processing
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}