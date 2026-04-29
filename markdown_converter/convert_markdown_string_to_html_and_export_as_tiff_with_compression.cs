// Convert a Markdown string to HTML and then export the result as a TIFF file with compression.

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
            string markdownContent = "# Sample Title\n\nThis is a **markdown** text.";
            string markdownPath = Path.Combine(Path.GetTempPath(), "sample.md");
            string tiffPath = Path.Combine(Path.GetTempPath(), "output.tiff");

            File.WriteAllText(markdownPath, markdownContent);

            HTMLDocument document = Converter.ConvertMarkdown(markdownPath);

            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
            options.Compression = Compression.None;
            options.HorizontalResolution = 150;
            options.VerticalResolution = 150;

            Converter.ConvertHTML(document, options, tiffPath);

            Console.WriteLine("TIFF file created at: " + tiffPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}