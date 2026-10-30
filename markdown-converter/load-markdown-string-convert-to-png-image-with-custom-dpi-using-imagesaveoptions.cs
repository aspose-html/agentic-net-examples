// Load a Markdown string and convert it to a PNG image with custom DPI using ImageSaveOptions.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            System.String markdown = "# Hello World\nThis is a sample markdown.";
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdown);

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
            options.Format = Aspose.Html.Rendering.Image.ImageFormat.Png;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            System.String outputPath = "output.png";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            System.Console.WriteLine("Conversion completed: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}