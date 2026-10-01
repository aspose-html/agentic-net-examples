// Load a Markdown string and convert it to a PNG image with custom DPI using ImageSaveOptions.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string markdown = "# Sample Markdown\nThis is a **bold** text.";
            string outputPath = "markdown_image.png";

            var document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdown);
            var options = new Aspose.Html.Saving.ImageSaveOptions();
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            Console.WriteLine("Markdown converted to image successfully: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}