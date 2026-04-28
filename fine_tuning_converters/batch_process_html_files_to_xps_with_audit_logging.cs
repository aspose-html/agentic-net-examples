// Batch process a collection of HTML files to XPS, logging each conversion result for audit purposes.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define source and destination folders
            string inputFolder = "InputHtml";
            string outputFolder = "OutputXps";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all HTML files in the input folder
            string[] files = Directory.GetFiles(inputFolder, "*.html");

            foreach (string htmlPath in files)
            {
                try
                {
                    // Load the HTML document
                    using (HTMLDocument document = new HTMLDocument(htmlPath))
                    {
                        // Initialize default XPS save options
                        XpsSaveOptions options = new XpsSaveOptions();

                        // Build the output XPS file path
                        string outputPath = Path.Combine(
                            outputFolder,
                            Path.GetFileNameWithoutExtension(htmlPath) + ".xps");

                        // Convert HTML to XPS
                        Converter.ConvertHTML(document, options, outputPath);

                        // Log successful conversion
                        Console.WriteLine($"Converted: {Path.GetFileName(htmlPath)} -> {Path.GetFileName(outputPath)}");
                    }
                }
                catch (Exception ex)
                {
                    // Log conversion failure for the current file
                    Console.WriteLine($"Failed: {Path.GetFileName(htmlPath)} - {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            // Log any unexpected errors that stop the batch process
            Console.WriteLine($"Fatal error: {ex.Message}");
        }
    }
}