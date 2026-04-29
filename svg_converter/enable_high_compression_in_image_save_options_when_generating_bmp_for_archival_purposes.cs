// Enable high compression in ImageSaveOptions when generating BMP for archival purposes.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string outputPath = "output.bmp";

            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
            options.Compression = Compression.Rle; // enable high compression for BMP

            Converter.ConvertHTML(htmlPath, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}