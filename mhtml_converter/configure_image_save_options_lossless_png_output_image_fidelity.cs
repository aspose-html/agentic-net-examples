// Configure ImageSaveOptions to enable lossless compression for PNG output when preserving image fidelity is critical.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.mhtml";
            string outputPath = "output.png";

            using (Stream stream = File.OpenRead(sourcePath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
                options.UseAntialiasing = true;
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                Converter.ConvertMHTML(stream, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}