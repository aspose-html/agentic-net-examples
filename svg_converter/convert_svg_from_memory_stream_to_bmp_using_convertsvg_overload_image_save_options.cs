// Convert an SVG loaded from a memory stream directly to BMP using ConvertSVG overload with ImageSaveOptions.

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
            // Load SVG data into a memory stream
            byte[] svgBytes = File.ReadAllBytes("input.svg");
            using (MemoryStream memoryStream = new MemoryStream(svgBytes))
            using (StreamReader reader = new StreamReader(memoryStream))
            {
                // Read SVG content as a string
                string svgContent = reader.ReadToEnd();

                // Define output BMP file path
                string outputPath = "output.bmp";

                // Initialize ImageSaveOptions with BMP format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

                // Convert SVG content to BMP image
                Converter.ConvertSVG(svgContent, ".", options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}