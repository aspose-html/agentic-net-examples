// Convert HTML with embedded fonts to TIFF after installing matching fonts in Docker to preserve text appearance.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create a minimal HTML file that references a custom font (assumed to be installed in the Docker image)
            string htmlPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><head><style>@font-face{font-family:'OpenSans';src:url('OpenSans-Regular.ttf') format('truetype');}body{font-family:'OpenSans';font-size:24px;}</style></head><body>Hello, world with custom font!</body></html>";
            System.IO.File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure image save options for TIFF
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            options.Compression = Aspose.Html.Rendering.Image.Compression.None;
            options.BackgroundColor = System.Drawing.Color.White;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Convert HTML to TIFF
            string outputPath = "output.tiff";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed: " + System.IO.Path.GetFullPath(outputPath));
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}