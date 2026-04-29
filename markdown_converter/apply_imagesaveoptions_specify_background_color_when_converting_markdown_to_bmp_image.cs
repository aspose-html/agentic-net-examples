// Apply ImageSaveOptions to specify background color when converting Markdown to a BMP image.

using System;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source Markdown file
            string markdownPath = "input.md";

            // Path where the BMP image will be saved
            string outputPath = "output.bmp";

            // Convert the Markdown file to an HTMLDocument
            HTMLDocument document = Converter.ConvertMarkdown(markdownPath);

            // Create ImageSaveOptions for BMP format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

            // Set the background color for the rendered image
            options.BackgroundColor = Color.Beige;

            // Render the HTMLDocument to a BMP image using the specified options
            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}