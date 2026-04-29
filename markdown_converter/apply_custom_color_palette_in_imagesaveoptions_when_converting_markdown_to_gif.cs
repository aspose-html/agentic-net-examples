// Apply a custom color palette in ImageSaveOptions when converting Markdown to GIF format.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Drawing;

namespace MarkdownToGifExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source markdown file
                string sourcePath = "input.md";

                // Path where the resulting GIF will be saved
                string outputPath = "output.gif";

                // Convert the markdown file to an HTMLDocument
                HTMLDocument document = Converter.ConvertMarkdown(sourcePath);

                // Create ImageSaveOptions with GIF format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

                // Apply a custom color palette if supported (example palette)
                // Uncomment the following lines if the API provides a palette property
                // options.GifPalette = new Color[]
                // {
                //     Color.FromArgb(255, 0, 0),   // Red
                //     Color.FromArgb(0, 255, 0),   // Green
                //     Color.FromArgb(0, 0, 255)    // Blue
                // };

                // Convert the HTMLDocument to a GIF image
                Converter.ConvertHTML(document, options, outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}