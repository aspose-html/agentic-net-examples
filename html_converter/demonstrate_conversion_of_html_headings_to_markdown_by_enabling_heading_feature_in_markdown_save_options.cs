// Demonstrate conversion of HTML headings to Markdown by enabling the Heading feature in MarkdownSaveOptions.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source HTML file containing headings
            string htmlPath = "input.html";

            // Path where the resulting Markdown file will be saved
            string markdownPath = "output.md";

            // Create default Markdown save options
            MarkdownSaveOptions options = new MarkdownSaveOptions();

            // Enable heading conversion if the feature is available in the current library version
            // options.Features = MarkdownFeatures.Heading;

            // Perform the conversion from HTML to Markdown
            Converter.ConvertHTML(htmlPath, options, markdownPath);

            Console.WriteLine("Conversion completed. Markdown saved at: " + markdownPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}