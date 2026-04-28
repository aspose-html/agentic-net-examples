// Enable anti‑aliasing for image conversion to produce smoother JPG output from HTML content.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source HTML file
            string htmlPath = "input.html";

            // Path for the resulting JPEG image
            string outputPath = "output.jpg";

            // Create image save options for JPEG format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

            // Enable anti‑aliasing for smoother output
            options.UseAntialiasing = true;

            // Convert the HTML document to a JPEG image with the specified options
            Converter.ConvertHTML(htmlPath, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}