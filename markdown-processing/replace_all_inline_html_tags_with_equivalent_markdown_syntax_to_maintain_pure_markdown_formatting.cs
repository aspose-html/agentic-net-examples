// Replace all inline HTML tags with equivalent Markdown syntax to maintain pure Markdown formatting.

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
            // Define input HTML file and output Markdown file paths
            string htmlPath = "sample.html";
            string outputPath = "output.md";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello World</h1><p>This is a <strong>sample</strong> paragraph with <a href=\"https://example.com\">a link</a>.</p></body></html>";
                File.WriteAllText(htmlPath, sampleHtml);
            }

            // Set Markdown conversion options
            MarkdownSaveOptions options = new MarkdownSaveOptions();

            // Convert HTML to Markdown
            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, outputPath);

            // Read and display the generated Markdown
            string markdown = File.ReadAllText(outputPath);
            Console.WriteLine("Converted Markdown content:");
            Console.WriteLine(markdown);
            Console.WriteLine("Conversion completed. Markdown saved at " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}