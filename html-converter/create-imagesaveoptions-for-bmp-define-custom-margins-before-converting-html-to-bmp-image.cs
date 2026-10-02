// Create an ImageSaveOptions for BMP and define custom margins prior to converting HTML to BMP image.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string inputPath = "sample.html";
            string outputPath = "output.bmp";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(inputPath, htmlContent);
            }

            // Load the HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                // Create ImageSaveOptions for BMP format
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);

                // Define custom page size and margins
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(800, 600),
                    new Aspose.Html.Drawing.Margin(50, 50, 50, 50));

                // Convert HTML to BMP image
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully. Output saved to: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}