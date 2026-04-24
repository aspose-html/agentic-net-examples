// Apply a GitLab Flavored Markdown template through MarkdownSaveOptions.Template before performing the conversion.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source HTML file
            string sourcePath = "input.html";

            // Path where the Markdown file will be saved
            string outputPath = "output.md";

            // Apply GitLab Flavored Markdown template
            MarkdownSaveOptions options = MarkdownSaveOptions.Git;

            // Perform the conversion
            Converter.ConvertHTML(sourcePath, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}