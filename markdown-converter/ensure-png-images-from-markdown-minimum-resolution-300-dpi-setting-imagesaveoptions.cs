// Ensure PNG images produced from Markdown have a minimum resolution of 300 DPI by setting ImageSaveOptions.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample markdown file
            string markdownPath = "sample.md";
            if (!File.Exists(markdownPath))
            {
                File.WriteAllText(markdownPath, "# Sample Title\n\nThis is a **markdown** document converted to PNG.");
            }

            // Convert markdown to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdownPath);

            // Set image save options with 300 DPI resolution
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Convert HTMLDocument to PNG image
            string outputPath = "output.png";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Markdown has been converted to PNG with 300 DPI at: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}