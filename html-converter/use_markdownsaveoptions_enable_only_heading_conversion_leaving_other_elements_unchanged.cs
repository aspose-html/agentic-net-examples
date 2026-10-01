// Use MarkdownSaveOptions to enable only heading conversion while leaving other elements unchanged.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<h1>Sample Title</h1><p>This is a paragraph.</p><a href='https://example.com'>Example Link</a>";
            string outputPath = "sample.md";

            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();
            // No additional features are set to keep only heading conversion (default behavior)

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, options, outputPath);

            Console.WriteLine("Conversion completed. Markdown saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}