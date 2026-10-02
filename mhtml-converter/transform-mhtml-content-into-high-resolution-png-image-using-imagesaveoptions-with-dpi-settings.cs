// Transform MHTML content into a high‑resolution PNG image using ImageSaveOptions with DPI settings.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input MHTML file and output PNG file paths
            string inputPath = "sample.mhtml";
            string outputPath = "output.png";

            // Create a minimal MHTML (HTML) file if it does not exist
            if (!File.Exists(inputPath))
            {
                string minimalHtml = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(inputPath, minimalHtml);
            }

            // Open the MHTML file as a stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Configure image save options with high resolution DPI
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                options.HorizontalResolution = 300; // DPI horizontally
                options.VerticalResolution = 300;   // DPI vertically
                options.UseAntialiasing = true;

                // Convert MHTML to PNG
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}