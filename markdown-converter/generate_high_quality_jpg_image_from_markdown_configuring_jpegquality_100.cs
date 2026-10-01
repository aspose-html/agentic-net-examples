// Generate a high‑quality JPG image from Markdown by configuring ImageSaveOptions JpegQuality to 100.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Define input markdown file and content
            string sourcePath = "sample.md";
            string markdownContent = "# Hello World\nThis is a sample markdown converted to an image.";
            // Write markdown content to file
            File.WriteAllText(sourcePath, markdownContent);

            // Convert markdown file to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Configure image save options for high-quality JPEG
            ImageSaveOptions options = new ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Define output image path
            string savePath = "output.jpg";

            // Convert HTMLDocument to JPEG image
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);

            Console.WriteLine("Conversion completed successfully. Image saved to: " + Path.GetFullPath(savePath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}