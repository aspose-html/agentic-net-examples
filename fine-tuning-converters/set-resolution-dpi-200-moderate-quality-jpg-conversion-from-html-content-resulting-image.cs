// Set ImageRenderingOptions.ResolutionDpi to 200 for moderate‑quality JPG conversion from HTML content in the resulting image.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlPath = "sample.html";
            string outputPath = "output.jpg";

            // Create a minimal HTML file if it does not exist
            if (!System.IO.File.Exists(htmlPath))
            {
                string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
                System.IO.File.WriteAllText(htmlPath, htmlContent);
            }

            // Configure image save options with 200 DPI
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.HorizontalResolution = 200;
            options.VerticalResolution = 200;

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(htmlPath);

            // Convert HTML to JPEG image
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}