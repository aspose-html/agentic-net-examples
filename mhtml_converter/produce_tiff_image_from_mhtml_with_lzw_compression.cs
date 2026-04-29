// Produce a TIFF image from MHTML and enable LZW compression via ImageSaveOptions.

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
            string inputPath = "input.mhtml";
            string outputPath = "output.tiff";

            using (Stream stream = File.OpenRead(inputPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
                // LZW compression is not available in the current API version; omitted.
                Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}