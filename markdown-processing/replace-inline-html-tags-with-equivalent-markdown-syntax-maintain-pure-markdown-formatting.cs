// Replace all inline HTML tags with equivalent Markdown syntax to maintain pure Markdown formatting.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML file and output Markdown file paths
            string htmlPath = "sample.html";
            string markdownPath = "sample.md";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello World</h1><p>This is a <strong>sample</strong> HTML document.</p></body></html>";
                File.WriteAllText(htmlPath, htmlContent);
            }

            // Set Markdown conversion options
            MarkdownSaveOptions options = new MarkdownSaveOptions();

            // Perform conversion from HTML to Markdown
            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, markdownPath);

            // Output result
            Console.WriteLine("Conversion completed. Markdown saved at " + markdownPath);
            Console.WriteLine("Markdown content:");
            Console.WriteLine(File.ReadAllText(markdownPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}