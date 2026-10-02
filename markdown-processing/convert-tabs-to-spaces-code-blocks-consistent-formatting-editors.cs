// Convert tabs to spaces within code blocks to maintain consistent formatting across editors.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello World</h1><p>This is a sample.</p></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            string outputPath = "output.md";

            Aspose.Html.Saving.MarkdownSaveOptions options = Aspose.Html.Saving.MarkdownSaveOptions.Git;

            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, outputPath);

            Console.WriteLine("Conversion completed. Markdown saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}