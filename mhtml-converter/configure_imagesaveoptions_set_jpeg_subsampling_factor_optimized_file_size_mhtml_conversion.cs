// Configure ImageSaveOptions to set JPEG subsampling factor for optimized file size during MHTML conversion.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><h1>Sample MHTML</h1></body></html>");
            }

            using (Stream stream = File.OpenRead(inputPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                options.HorizontalResolution = 96;
                options.VerticalResolution = 96;

                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}