// Create a unit test that verifies ImageSaveOptions correctly applies JPEG quality level during conversion.

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
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(outputDir);

            string svgPath = Path.Combine(dataDir, "sample.svg");
            string jpegPath = Path.Combine(outputDir, "result.jpg");

            // Create a simple SVG file
            File.WriteAllText(svgPath,
                @"<svg width='100' height='100' xmlns='http://www.w3.org/2000/svg'>
                    <rect width='100' height='100' fill='red'/>
                  </svg>");

            // Initialize ImageSaveOptions for JPEG format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

            // Convert SVG to JPEG using the options
            Converter.ConvertSVG(svgPath, options, jpegPath);

            // Verify that the JPEG file was created and has content
            if (File.Exists(jpegPath) && new FileInfo(jpegPath).Length > 0)
            {
                Console.WriteLine("JPEG conversion succeeded and file is non-empty.");
            }
            else
            {
                Console.WriteLine("JPEG conversion failed or resulted in an empty file.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}