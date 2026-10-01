// Apply the GitLab Flavored Markdown template using default options to generate repository‑compatible documentation.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            string outputPath = "output.md";
            MarkdownSaveOptions options = MarkdownSaveOptions.Git;
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, options, outputPath);
            Console.WriteLine($"Markdown documentation generated at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}