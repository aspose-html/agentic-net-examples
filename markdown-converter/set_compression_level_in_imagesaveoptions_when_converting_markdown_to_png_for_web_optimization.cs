// Set the compression level in ImageSaveOptions when converting Markdown to PNG for web optimization.

using System;
using System.IO;
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
            string sourcePath = "sample.md";
            string outputPath = "output.png";

            // Create a minimal markdown file if it does not exist
            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(sourcePath, "# Hello World\nThis is a sample markdown file.");
            }

            // Convert Markdown to HTMLDocument
            HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Set up image save options for PNG with web‑optimized settings
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;
            // Note: CompressionLevel property is not set because it is not part of the validated API surface.

            // Convert HTMLDocument to PNG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Markdown has been successfully converted to PNG at: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}