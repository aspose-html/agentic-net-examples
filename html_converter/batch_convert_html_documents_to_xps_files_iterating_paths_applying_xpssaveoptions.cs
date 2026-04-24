// Batch convert multiple HTML documents to XPS files by iterating paths and applying XpsSaveOptions.

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
            // Folder containing source HTML files
            string inputFolder = @"C:\InputHtml";
            // Folder where XPS files will be saved
            string outputFolder = @"C:\OutputXps";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Iterate over all HTML files in the input folder
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                // Load the HTML document
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    // Create default XPS save options
                    XpsSaveOptions options = new XpsSaveOptions();

                    // Build the output XPS file path
                    string outputPath = Path.Combine(
                        outputFolder,
                        Path.GetFileNameWithoutExtension(htmlPath) + ".xps");

                    // Convert the HTML document to XPS
                    Converter.ConvertHTML(document, options, outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            // Output any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}