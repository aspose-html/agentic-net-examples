// Generate a BMP file from MHTML source while preserving original color depth using default options.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.mhtml";
            string outputPath = "output.bmp";

            Stream stream = File.OpenRead(inputPath);
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
            Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            Console.WriteLine("Conversion completed successfully.");
            stream.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}