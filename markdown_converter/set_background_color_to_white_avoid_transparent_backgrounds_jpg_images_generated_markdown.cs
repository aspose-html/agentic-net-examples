// Set ImageSaveOptions.BackgroundColor to white to avoid transparent backgrounds in JPG images generated from Markdown.

using System;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

namespace MarkdownToJpg
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source markdown file
                string sourcePath = "input.md";

                // Path where the resulting JPEG image will be saved
                string outputPath = "output.jpg";

                // Convert the markdown file to an HTMLDocument
                HTMLDocument document = Converter.ConvertMarkdown(sourcePath);

                // Create image save options for JPEG format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

                // Optional rendering settings
                options.UseAntialiasing = true;
                options.HorizontalResolution = 200;
                options.VerticalResolution = 200;

                // Set background color to white to avoid transparency
                options.BackgroundColor = Color.White;

                // Render the HTMLDocument to a JPEG image
                Converter.ConvertHTML(document, options, outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}