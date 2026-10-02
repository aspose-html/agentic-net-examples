// Convert an HTML file to a BMP image with default options by specifying source and destination paths.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.html");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.bmp");

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Set up image save options for BMP format
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);

            // Convert HTML to BMP image
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}