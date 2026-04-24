// Configure MarkdownSaveOptions to enable only link conversion and apply these options during conversion.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace HtmlToMarkdownExample
{
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

                // Create Markdown save options
                MarkdownSaveOptions options = new MarkdownSaveOptions();

                // Enable only link conversion
                options.Features = MarkdownFeatures.Link;

                // Perform the conversion
                Converter.ConvertHTML(htmlPath, options, markdownPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}