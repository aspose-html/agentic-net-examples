// Convert a Markdown string to HTML and then export the result as a TIFF file with compression.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define markdown content
            string markdown = "# Sample Title\n\nThis is a **markdown** text.";

            // Create a temporary markdown file
            string sourcePath = Path.Combine(Path.GetTempPath(), "sample.md");
            File.WriteAllText(sourcePath, markdown);

            // Convert markdown file to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Set up image save options for TIFF
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            options.Compression = Aspose.Html.Rendering.Image.Compression.None;

            // Define output TIFF path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.tiff");

            // Convert HTMLDocument to TIFF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed. TIFF saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}