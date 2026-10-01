// Create a command‑line tool that accepts an input HTML path and outputs a PNG with specified DPI.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello Aspose.HTML</h1></body></html>";

            // Load HTML document from string
            var document = new Aspose.Html.HTMLDocument(htmlContent);

            // Configure image save options with resolution
            var options = new Aspose.Html.Saving.ImageSaveOptions();
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Output file path
            string outputPath = "output.png";

            // Convert HTML to image
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output file: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}