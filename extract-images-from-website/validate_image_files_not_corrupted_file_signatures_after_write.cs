// Validate that saved image files are not corrupted by checking file signatures after write operation.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare directories
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            Directory.CreateDirectory(dataDir);
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);

            // Create a minimal SVG file
            string svgPath = Path.Combine(dataDir, "sample.svg");
            if (!File.Exists(svgPath))
            {
                string svgContent = @"<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'>
  <rect width='100' height='100' fill='red' />
</svg>";
                File.WriteAllText(svgPath, svgContent);
            }

            // Define output paths
            string highOutputPath = Path.Combine(outputDir, "high.jpg");
            string lowOutputPath = Path.Combine(outputDir, "low.jpg");

            // Convert SVG to JPEG with default options
            var highOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            var lowOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, highOptions, highOutputPath);
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, lowOptions, lowOutputPath);

            // Validate JPEG signatures
            bool highValid = IsJpeg(highOutputPath);
            bool lowValid = IsJpeg(lowOutputPath);

            if (highValid && lowValid)
            {
                Console.WriteLine("Both images are valid JPEG files.");
            }
            else
            {
                if (!highValid)
                    Console.WriteLine("High-quality image is corrupted or not a JPEG.");
                if (!lowValid)
                    Console.WriteLine("Low-quality image is corrupted or not a JPEG.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static bool IsJpeg(string path)
    {
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            byte[] header = new byte[3];
            int read = fs.Read(header, 0, 3);
            return read == 3 && header[0] == 0xFF && header[1] == 0xD8 && header[2] == 0xFF;
        }
    }
}