// Load a Markdown string and convert it to a PNG image with custom DPI using ImageSaveOptions.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Markdown content to be converted
            string markdown = "# Sample Title\nThis is a **markdown** string.";

            // Write markdown to a temporary file (required by ConvertMarkdown overload)
            string markdownPath = Path.Combine(Path.GetTempPath(), "sample.md");
            File.WriteAllText(markdownPath, markdown);

            // Define output PNG file path
            string outputPath = Path.Combine(Path.GetTempPath(), "output.png");

            // Convert markdown file to an HTMLDocument
            HTMLDocument document = Converter.ConvertMarkdown(markdownPath);

            // Create ImageSaveOptions and set custom DPI
            ImageSaveOptions options = new ImageSaveOptions();
            options.HorizontalResolution = 300; // DPI horizontally
            options.VerticalResolution = 300;   // DPI vertically

            // Render the HTMLDocument to PNG using the configured options
            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Conversion failed: " + ex.Message);
        }
    }
}