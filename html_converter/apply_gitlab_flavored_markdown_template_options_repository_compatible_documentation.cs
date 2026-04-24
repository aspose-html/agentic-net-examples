// Apply the GitLab Flavored Markdown template using default options to generate repository‑compatible documentation.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Define the output markdown file path
            string outputPath = "output.md";

            // Use GitLab Flavored Markdown options
            MarkdownSaveOptions options = MarkdownSaveOptions.Git;

            // Convert the HTML file to markdown using the Git preset
            Converter.ConvertHTML("input.html", options, outputPath);

            Console.WriteLine("HTML successfully converted to GitLab Flavored Markdown.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}