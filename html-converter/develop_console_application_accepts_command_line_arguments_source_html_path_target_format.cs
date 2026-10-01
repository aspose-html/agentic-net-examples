// Develop a console application that accepts command‑line arguments for source HTML path and target format.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Determine source HTML path
            string sourcePath;
            if (args.Length > 0 && File.Exists(args[0]))
            {
                sourcePath = args[0];
            }
            else
            {
                // Create a minimal sample HTML file
                sourcePath = Path.Combine(Path.GetTempPath(), "sample.html");
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(sourcePath, sampleHtml);
            }

            // Determine target format
            string targetFormat = (args.Length > 1) ? args[1].ToLowerInvariant() : "markdown";

            // Read HTML content
            string htmlContent = File.ReadAllText(sourcePath);
            string baseUri = Path.GetDirectoryName(sourcePath) ?? "";

            // Prepare output path based on format
            string outputPath;
            if (targetFormat == "markdown")
            {
                outputPath = Path.ChangeExtension(sourcePath, ".md");
                var options = new Aspose.Html.Saving.MarkdownSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);
            }
            else if (targetFormat == "mhtml")
            {
                outputPath = Path.ChangeExtension(sourcePath, ".mht");
                var options = new Aspose.Html.Saving.MHTMLSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);
            }
            else
            {
                Console.WriteLine("Unsupported target format. Use 'markdown' or 'mhtml'.");
                return;
            }

            Console.WriteLine($"Conversion successful. Output saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}