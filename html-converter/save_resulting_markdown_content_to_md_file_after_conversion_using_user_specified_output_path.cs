// Save the resulting Markdown content to a .md file after conversion using a user‑specified output path.

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
            string htmlContent = "<html><body><h1>Hello World</h1><p>This is a sample HTML.</p></body></html>";
            string baseUri = "";

            // Create Markdown save options
            MarkdownSaveOptions options = new MarkdownSaveOptions();

            // Temporary file to store intermediate markdown
            string tempPath = Path.GetTempFileName();

            // Convert HTML to Markdown and save to temporary file
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);

            // Read the generated markdown content
            string markdown = File.ReadAllText(tempPath);

            // Delete the temporary file
            File.Delete(tempPath);

            // User‑specified output path for the final markdown file
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "result.md");

            // Ensure the directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save markdown content to the specified .md file
            File.WriteAllText(outputPath, markdown);

            Console.WriteLine($"Markdown file saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}