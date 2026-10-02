// Apply the GitLab Flavored Markdown template using default options to generate repository‑compatible documentation.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "output.md";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1><p>This is a sample HTML file.</p></body></html>";
                File.WriteAllText(inputPath, htmlContent);
            }

            // Use default GitLab Flavored Markdown options
            MarkdownSaveOptions options = MarkdownSaveOptions.Git;

            // Convert HTML to Markdown
            Aspose.Html.Converters.Converter.ConvertHTML(inputPath, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Markdown saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}