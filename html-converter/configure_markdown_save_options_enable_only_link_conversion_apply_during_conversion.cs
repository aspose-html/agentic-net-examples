// Configure MarkdownSaveOptions to enable only link conversion and apply these options during conversion.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><a href='https://example.com'>Example</a></body></html>";
            string outputPath = "output.md";

            MarkdownSaveOptions options = new MarkdownSaveOptions();
            options.Features = MarkdownFeatures.Link;

            Aspose.Html.Converters.Converter.ConvertHTML(html, options, outputPath);
            Console.WriteLine("Conversion completed successfully. Output saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}