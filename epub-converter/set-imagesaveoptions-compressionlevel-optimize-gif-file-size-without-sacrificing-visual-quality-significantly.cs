// Set ImageSaveOptions.CompressionLevel to optimize GIF file size without sacrificing visual quality significantly.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML and output GIF paths
            string htmlPath = "sample.html";
            string outputPath = "output.gif";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<html><body><h1>Sample GIF Conversion</h1></body></html>");
            }

            // Configure image save options for GIF
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Convert HTML to GIF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("GIF conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}