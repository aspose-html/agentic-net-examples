// Test conversion of HTML containing script tags to ensure scripts are omitted from the resulting Markdown.

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
            // Sample HTML containing a script tag
            string htmlContent = "<html><head><script>console.log('test');</script></head><body><h1>Hello</h1><p>World</p></body></html>";
            string baseUri = "about:blank";

            // Configure Markdown save options
            MarkdownSaveOptions options = new MarkdownSaveOptions();

            // Prepare output file path
            string tempFile = Path.GetTempFileName();
            string outputPath = Path.ChangeExtension(tempFile, ".md");

            // Convert HTML to Markdown, scripts should be omitted
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);

            // Read and display the resulting Markdown
            string markdown = File.ReadAllText(outputPath);
            Console.WriteLine("Converted Markdown:");
            Console.WriteLine(markdown);
            Console.WriteLine("Conversion completed. Markdown saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}