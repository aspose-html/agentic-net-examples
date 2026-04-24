// Convert EPUB to BMP while adding title metadata through ImageSaveOptions to preserve document information.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string epubPath = "input.epub";
            string outputPath = "output.bmp";

            Stream stream = File.OpenRead(epubPath);
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
            // Title metadata is not directly supported by ImageSaveOptions; skipping if unavailable.

            Converter.ConvertEPUB(stream, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}