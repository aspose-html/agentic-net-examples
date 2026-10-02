// Convert a Markdown file to GIF format while limiting the animation frame rate using ImageSaveOptions.

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
            // Define input and output paths
            string sourcePath = "sample.md";
            string savePath = "output.gif";

            // Create a minimal markdown file
            string markdownContent = "# Sample Markdown\n\nThis is a **test** of Markdown to GIF conversion.";
            File.WriteAllText(sourcePath, markdownContent);

            // Convert Markdown to HTMLDocument
            HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Set image save options for GIF format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

            // Convert HTMLDocument to GIF image
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + Path.GetFullPath(savePath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}