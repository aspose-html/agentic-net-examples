// Ensure that temporary HTML files created during conversion are deleted after the final output is saved.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello World</h1><p>This is a sample.</p></body></html>";
            string baseUri = "http://example.com";

            // Temporary file for intermediate markdown output
            string tempPath = Path.GetTempFileName();

            // Convert HTML to Markdown and save to temporary file
            MarkdownSaveOptions mdOptions = new MarkdownSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, mdOptions, tempPath);

            // Read markdown from temporary file
            string markdown = File.ReadAllText(tempPath);

            // Delete the temporary file
            File.Delete(tempPath);

            // Final output path
            string outputPath = Path.Combine(Path.GetTempPath(), "output.md");
            File.WriteAllText(outputPath, markdown);

            Console.WriteLine("Markdown saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}