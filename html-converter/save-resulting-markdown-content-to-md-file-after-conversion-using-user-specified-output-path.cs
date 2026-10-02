// Save the resulting Markdown content to a .md file after conversion using a user‑specified output path.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello World</h1><p>This is a sample.</p></body></html>";
            string baseUri = "about:blank";

            // Set up Markdown save options
            var options = new Aspose.Html.Saving.MarkdownSaveOptions();

            // Convert HTML to Markdown and save to a temporary file
            string tempPath = Path.GetTempFileName();
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);

            // Read the generated Markdown content
            string markdown = File.ReadAllText(tempPath);
            File.Delete(tempPath);

            // User‑specified output path for the final .md file
            string outputPath = "output/document.md";
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Save the Markdown content to the specified file
            File.WriteAllText(outputPath, markdown);

            Console.WriteLine($"Markdown saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}