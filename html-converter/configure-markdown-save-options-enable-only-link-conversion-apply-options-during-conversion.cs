// Configure MarkdownSaveOptions to enable only link conversion and apply these options during conversion.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><a href='https://example.com'>Example</a></body></html>";
            string outputPath = "output.md";

            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();
            options.Features = Aspose.Html.Saving.MarkdownFeatures.Link;

            Aspose.Html.Converters.Converter.ConvertHTML(html, options, outputPath);

            Console.WriteLine("Conversion completed. Output saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}