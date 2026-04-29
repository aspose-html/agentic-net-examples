// Use ImageSaveOptions to specify color depth when converting Markdown to BMP format.

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
            string markdownPath = "sample.md";
            string outputPath = "sample.bmp";

            if (!File.Exists(markdownPath))
            {
                File.WriteAllText(markdownPath, "# Hello World\r\nThis is a sample markdown.");
            }

            HTMLDocument document = Converter.ConvertMarkdown(markdownPath);
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}