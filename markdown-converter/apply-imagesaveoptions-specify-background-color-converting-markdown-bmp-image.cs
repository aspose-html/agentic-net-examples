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
            string markdown = "### Hello, World!\r\n[visit applications](https://products.aspose.app/html/family)";

            // Convert markdown to HTMLDocument
            HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdown);

            // Configure image save options with background color
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
            options.BackgroundColor = Color.Beige;

            // Define output file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.bmp");

            // Convert HTML to BMP image
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed. Image saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}