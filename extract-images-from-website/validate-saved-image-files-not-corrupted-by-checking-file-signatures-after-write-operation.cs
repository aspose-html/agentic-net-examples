// Validate that saved image files are not corrupted by checking file signatures after write operation.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare folders
            string inputFolder = "Input";
            string outputFolder = "Output";
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a simple SVG file
            string svgPath = Path.Combine(inputFolder, "sample.svg");
            string svgContent = @"<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'>
  <rect width='200' height='200' fill='lightblue'/>
  <circle cx='100' cy='100' r='80' fill='orange'/>
</svg>";
            File.WriteAllText(svgPath, svgContent);

            // Output paths
            string highOutputPath = Path.Combine(outputFolder, "high.jpg");
            string lowOutputPath = Path.Combine(outputFolder, "low.jpg");

            // High quality options (higher resolution)
            ImageSaveOptions highOptions = new ImageSaveOptions(ImageFormat.Jpeg);
            highOptions.HorizontalResolution = 300;
            highOptions.VerticalResolution = 300;

            // Low quality options (lower resolution)
            ImageSaveOptions lowOptions = new ImageSaveOptions(ImageFormat.Jpeg);
            lowOptions.HorizontalResolution = 72;
            lowOptions.VerticalResolution = 72;

            // Convert SVG to JPEG with both options
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, highOptions, highOutputPath);
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, lowOptions, lowOutputPath);

            // Compare file sizes
            long highSize = new FileInfo(highOutputPath).Length;
            long lowSize = new FileInfo(lowOutputPath).Length;
            if (highSize > lowSize)
            {
                Console.WriteLine("High resolution image is larger than low resolution image.");
            }
            else
            {
                Console.WriteLine("Low resolution image is larger than high resolution image.");
            }

            // Validate JPEG signatures
            byte[] jpegSignature = new byte[] { 0xFF, 0xD8, 0xFF };

            bool highValid = CheckSignature(highOutputPath, jpegSignature);
            bool lowValid = CheckSignature(lowOutputPath, jpegSignature);

            Console.WriteLine(highValid ? "High image file is valid." : "High image file is corrupted.");
            Console.WriteLine(lowValid ? "Low image file is valid." : "Low image file is corrupted.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static bool CheckSignature(string filePath, byte[] expectedSignature)
    {
        if (!File.Exists(filePath))
            return false;

        byte[] buffer = new byte[expectedSignature.Length];
        using (FileStream fs = File.OpenRead(filePath))
        {
            int read = fs.Read(buffer, 0, buffer.Length);
            if (read != buffer.Length)
                return false;
        }

        for (int i = 0; i < expectedSignature.Length; i++)
        {
            if (buffer[i] != expectedSignature[i])
                return false;
        }
        return true;
    }
}