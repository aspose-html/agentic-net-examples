// Create an ImageSaveOptions for TIFF and specify compression level before converting HTML to TIFF file.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML file path
            string htmlPath = "sample.html";
            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            // Define output TIFF file path
            string outputPath = "output.tiff";

            // Load HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Create image save options for TIFF
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            // Optionally set resolution
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Convert HTML to TIFF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}