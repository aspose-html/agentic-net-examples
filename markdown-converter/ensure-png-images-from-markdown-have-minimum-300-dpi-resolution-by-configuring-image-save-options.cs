// Ensure PNG images produced from Markdown have a minimum resolution of 300 DPI by setting ImageSaveOptions.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string markdownPath = "sample.md";
            string outputPath = "output.png";

            // Create a sample markdown file if it does not exist
            if (!File.Exists(markdownPath))
            {
                File.WriteAllText(markdownPath, "# Sample Markdown\nThis is a test document.");
            }

            // Convert Markdown to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdownPath);

            // Set image save options with 300 DPI resolution
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Convert HTMLDocument to PNG image
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Image saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}