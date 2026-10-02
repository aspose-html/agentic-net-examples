// Perform conversion with default MarkdownSaveOptions and confirm that all supported HTML elements are converted.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Header</h1><p>Paragraph with <a href='https://example.com'>link</a>.</p><ul><li>Item 1</li><li>Item 2</li></ul><img src='https://via.placeholder.com/150' alt='Sample Image' /></body></html>";
            string baseUri = "about:blank";
            string outputPath = "output.md";

            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);

            Console.WriteLine("Conversion completed. Markdown saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}