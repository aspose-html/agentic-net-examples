// Process a collection of HTML files into DOCX documents with custom DocSaveOptions in a single batch.

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
            // Define sample HTML file paths
            string[] htmlFiles = new string[]
            {
                "sample1.html",
                "sample2.html"
            };

            // Ensure sample files exist
            foreach (string htmlPath in htmlFiles)
            {
                if (!File.Exists(htmlPath))
                {
                    string sampleContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Sample Document</h1></body></html>";
                    File.WriteAllText(htmlPath, sampleContent);
                }
            }

            // Process each HTML file and convert to DOCX
            foreach (string htmlPath in htmlFiles)
            {
                // Load HTML document
                HTMLDocument document = new HTMLDocument(htmlPath);

                // Prepare custom DocSaveOptions (default options used here)
                DocSaveOptions saveOptions = new DocSaveOptions();

                // Determine output DOCX path
                string outputPath = Path.ChangeExtension(htmlPath, ".docx");

                // Convert HTML to DOCX
                Aspose.Html.Converters.Converter.ConvertHTML(document, saveOptions, outputPath);

                Console.WriteLine($"Converted '{htmlPath}' to '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}