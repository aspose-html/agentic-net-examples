// Generate a high‑quality JPG image from Markdown by configuring ImageSaveOptions JpegQuality to 100.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define markdown content and file paths
            string sourcePath = "sample.md";
            string markdown = "# Hello World\nThis is a **markdown** sample.";
            string savePath = "output.jpg";

            // Write markdown content to a file
            File.WriteAllText(sourcePath, markdown);

            // Convert markdown file to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Configure image save options for high-quality JPEG
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Convert HTMLDocument to JPEG image
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);

            Console.WriteLine($"Markdown has been converted to high-quality JPEG at: {Path.GetFullPath(savePath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}