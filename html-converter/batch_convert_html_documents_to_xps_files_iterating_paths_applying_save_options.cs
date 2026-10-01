// Batch convert multiple HTML documents to XPS files by iterating paths and applying XpsSaveOptions.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputXps";

            // Ensure input and output directories exist
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file if none exist
            string[] existingFiles = Directory.GetFiles(inputFolder, "*.html");
            if (existingFiles.Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.html");
                File.WriteAllText(samplePath, "<!DOCTYPE html><html><body><h1>Sample HTML</h1></body></html>");
            }

            // Batch conversion
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    XpsSaveOptions options = new XpsSaveOptions();
                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".xps");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                    Console.WriteLine($"Converted '{htmlPath}' to '{outputPath}'.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}