// Convert a large Markdown file to BMP format using streaming to avoid high memory consumption.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (args.Length < 2)
                throw new ArgumentException("Usage: <markdownFilePath> <outputBmpPath>");

            string markdownPath = args[0];
            string outputBmpPath = args[1];

            // Convert Markdown file to HTMLDocument
            Aspose.Html.HTMLDocument document = Converter.ConvertMarkdown(markdownPath);

            // Set up image save options for BMP format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

            // Render HTMLDocument to BMP image and save to the specified path
            Converter.ConvertHTML(document, options, outputBmpPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}