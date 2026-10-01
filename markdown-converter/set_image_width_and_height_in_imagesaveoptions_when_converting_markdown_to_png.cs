// Set image width and height in ImageSaveOptions when converting Markdown to a PNG file.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string sourcePath = "sample.md";
            string outputPath = "output.png";

            // Create a minimal markdown file
            string markdownContent = "# Hello World\nThis is a sample markdown file.";
            File.WriteAllText(sourcePath, markdownContent);

            // Convert markdown to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Configure image save options with desired width and height
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.UseAntialiasing = true;
            // Set page size (width: 800px, height: 600px) and zero margins
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(800, 600),
                new Aspose.Html.Drawing.Margin(0, 0, 0, 0));

            // Convert HTML to PNG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Markdown has been successfully converted to PNG: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}