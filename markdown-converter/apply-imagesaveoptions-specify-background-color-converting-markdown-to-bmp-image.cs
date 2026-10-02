// Apply ImageSaveOptions to specify background color when converting Markdown to a BMP image.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Sample markdown content
            string markdown = "### Hello, World!\n[Visit Aspose](https://products.aspose.app/html/family)";

            // Convert markdown to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdown);

            // Configure image save options with background color
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
            options.BackgroundColor = System.Drawing.Color.Beige;
            options.UseAntialiasing = false;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Prepare output path
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "markdown_image.bmp");

            // Convert HTML to BMP image
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Markdown successfully converted to BMP image at:");
            Console.WriteLine(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}