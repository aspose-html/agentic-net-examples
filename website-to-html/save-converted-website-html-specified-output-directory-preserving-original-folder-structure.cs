// Save the converted website HTML to a specified output directory preserving original folder structure.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Input and output directories
            string inputFolder = "InputSite";
            string outputFolder = "OutputSite";

            // Ensure directories exist
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a minimal sample HTML file if none exist
            string sampleFile = Path.Combine(inputFolder, "index.html");
            if (!File.Exists(sampleFile))
            {
                File.WriteAllText(sampleFile, "<html><body><h1>Hello World</h1></body></html>");
            }

            // Process all HTML files recursively
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html", SearchOption.AllDirectories))
            {
                // Compute relative path and corresponding output path with .pdf extension
                string relativePath = Path.GetRelativePath(inputFolder, htmlPath);
                string outputRelativePath = Path.ChangeExtension(relativePath, ".pdf");
                string outputPath = Path.Combine(outputFolder, outputRelativePath);

                // Ensure the output subdirectory exists
                string outputDir = Path.GetDirectoryName(outputPath);
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                // Load HTML document
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    // Configure PDF save options (default options)
                    PdfSaveOptions options = new PdfSaveOptions();

                    // Convert HTML to PDF preserving folder structure
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