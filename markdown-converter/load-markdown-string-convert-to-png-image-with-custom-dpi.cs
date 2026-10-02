// Load a Markdown string and convert it to a PNG image with custom DPI using ImageSaveOptions.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string markdown = "# Sample Title\n\nThis is a **markdown** document.";
            string outputPath = "markdown.png";

            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdown);

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine($"Markdown converted to PNG successfully: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}