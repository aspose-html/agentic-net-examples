// Convert Markdown to PNG with transparent background by configuring ImageSaveOptions appropriately.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Prepare sample markdown file
            string sourcePath = "sample.md";
            string markdownContent = "# Hello World\nThis is a **markdown** sample.";
            File.WriteAllText(sourcePath, markdownContent);

            // Convert markdown to HTML document
            HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Configure image save options for PNG with transparent background
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
            options.BackgroundColor = Color.Transparent;
            options.UseAntialiasing = true;

            // Define output PNG path
            string outputPath = "output.png";

            // Convert HTML document to PNG image
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output file: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}