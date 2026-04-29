// Apply a custom resolution setting in ImageSaveOptions when converting Markdown to GIF images.

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

            // Path where the resulting GIF image will be saved
            string savePath = "output.gif";

            // Convert the Markdown file to an HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Create ImageSaveOptions for GIF format
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);

            // Apply custom resolution settings (e.g., 300 DPI)
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Render the HTMLDocument to a GIF image using the configured options
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}