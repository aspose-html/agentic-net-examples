// Apply CSS media type “print” in ImageSaveOptions before converting HTML to JPEG for accurate print layout.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input HTML file and output JPEG file paths
            string htmlPath = "sample.html";
            string outputPath = "output.jpg";

            // Create a minimal HTML file if it does not exist
            if (!System.IO.File.Exists(htmlPath))
            {
                System.IO.File.WriteAllText(htmlPath,
                    "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello, World!</h1></body></html>");
            }

            // Configure image save options with JPEG format and print media type
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.Css.MediaType = Aspose.Html.Rendering.MediaType.Print;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(htmlPath);

            // Convert HTML to JPEG using the configured options
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}