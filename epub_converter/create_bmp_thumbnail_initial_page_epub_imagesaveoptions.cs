// Create a BMP thumbnail representing page one of an EPUB using ImageSaveOptions to select the initial page.

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
            string epubPath = "sample.epub";
            string outputPath = "thumbnail.bmp";

            using (Stream stream = File.OpenRead(epubPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("Thumbnail created successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}