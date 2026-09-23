// Apply a uniform DPI setting in ImageSaveOptions to ensure consistent resolution across all GIF pages.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input HTML file and output GIF file paths
            string htmlPath = "input.html";
            string outputPath = "output.gif";

            // Create a minimal HTML file if it does not exist
            if (!System.IO.File.Exists(htmlPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello GIF</h1></body></html>";
                System.IO.File.WriteAllText(htmlPath, sampleHtml);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure image save options for GIF with uniform DPI
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Convert HTML to GIF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            System.Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}