// Configure ImageSaveOptions to set pixel format to 24‑bit when converting MHTML to BMP for compatibility.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

namespace MhtmlToBmp
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.mhtml";
                string outputPath = "output.bmp";

                using (Stream stream = File.OpenRead(inputPath))
                {
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}