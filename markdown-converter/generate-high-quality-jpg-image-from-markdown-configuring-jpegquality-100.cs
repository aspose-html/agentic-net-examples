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
            string sourcePath = "sample.md";
            string markdown = "# Sample Markdown\nThis is a **high‑quality** JPEG image generated from Markdown.";
            File.WriteAllText(sourcePath, markdown);

            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            Aspose.Html.Saving.ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            string savePath = "output.jpg";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);

            Console.WriteLine("Image saved to: " + savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}