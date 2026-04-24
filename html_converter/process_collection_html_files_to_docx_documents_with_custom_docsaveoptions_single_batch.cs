// Process a collection of HTML files into DOCX documents with custom DocSaveOptions in a single batch.

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
            // Input and output directories (defaults if not provided)
            string inputDir = args.Length > 0 ? args[0] : "input";
            string outputDir = args.Length > 1 ? args[1] : "output";

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Retrieve all HTML files from the input directory
            string[] htmlFiles = Directory.GetFiles(inputDir, "*.html");

            foreach (string htmlPath in htmlFiles)
            {
                // Load the HTML document from file
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

                // Create DocSaveOptions (customize properties here if needed)
                Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();

                // Build the output DOCX file path
                string fileName = Path.GetFileNameWithoutExtension(htmlPath);
                string docxPath = Path.Combine(outputDir, fileName + ".docx");

                // Convert HTML to DOCX using Aspose.Html
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, docxPath);
            }

            Console.WriteLine("Batch conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}