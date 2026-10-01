// Apply a GitLab Flavored Markdown template through MarkdownSaveOptions.Template before performing the conversion.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><body><h1>Hello World</h1><p>This is a sample paragraph.</p></body></html>";
            string outputPath = "output.md";

            Aspose.Html.Saving.MarkdownSaveOptions options = Aspose.Html.Saving.MarkdownSaveOptions.Git;

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, options, outputPath);

            Console.WriteLine($"Markdown file created at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}