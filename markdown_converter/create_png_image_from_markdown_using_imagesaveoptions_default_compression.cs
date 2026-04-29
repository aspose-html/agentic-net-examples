// Create a PNG image from Markdown using ImageSaveOptions with ImageFormat.Png and default compression.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source Markdown file
            string sourcePath = "input.md";

            // Path where the PNG image will be saved
            string savePath = "output.png";

            // Convert the Markdown file to an HTMLDocument
            HTMLDocument document = Converter.ConvertMarkdown(sourcePath);

            // Create ImageSaveOptions with PNG format (default compression)
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);

            // Render the HTMLDocument to a PNG image file
            Converter.ConvertHTML(document, options, savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}