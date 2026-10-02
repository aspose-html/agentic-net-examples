// Save the converted website HTML to a specified output directory preserving original folder structure.

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
            // Input and output directories
            string inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "input");
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "output");

            // Ensure directories exist
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a minimal sample HTML file if none exist
            string sampleHtmlPath = Path.Combine(inputFolder, "index.html");
            if (!File.Exists(sampleHtmlPath))
            {
                File.WriteAllText(sampleHtmlPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            // Process all HTML files preserving folder structure
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html", SearchOption.AllDirectories))
            {
                // Compute relative path and corresponding output path with .mhtml extension
                string relativePath = Path.GetRelativePath(inputFolder, htmlPath);
                string outputRelativePath = Path.ChangeExtension(relativePath, ".mhtml");
                string outputPath = Path.Combine(outputFolder, outputRelativePath);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load HTML document
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    // Configure MHTML save options
                    MHTMLSaveOptions options = new MHTMLSaveOptions();

                    // Convert and save
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}