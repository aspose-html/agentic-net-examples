// Convert HTML to Markdown using file path input and default options, then save to a specified .md file.

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
            string htmlPath = "input.html";

            // Path where the resulting Markdown file will be saved
            string markdownPath = "output.md";

            // Create default Markdown save options
            MarkdownSaveOptions options = new MarkdownSaveOptions();

            // Perform the conversion from HTML to Markdown
            Converter.ConvertHTML(htmlPath, options, markdownPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}