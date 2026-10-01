// Create an ImageSaveOptions for JPEG and set quality level before converting HTML to JPEG image.

using System;

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlPath = "input.html";
                string outputPath = "output.jpg";

                // Create a minimal HTML file if it does not exist
                if (!System.IO.File.Exists(htmlPath))
                {
                    System.IO.File.WriteAllText(htmlPath, "<h1>Convert HTML to JPEG</h1>");
                }

                // Configure image save options for JPEG
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;
                // Note: JPEG quality property is not available in this API version

                // Load the HTML document
                var document = new Aspose.Html.HTMLDocument(htmlPath);

                // Convert HTML to JPEG image
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}