// Set custom DPI of 150 in ImageSaveOptions before converting HTML to TIFF for medium‑resolution output.

using System;
using System.Drawing;
using Aspose.Html;
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

            // Path where the TIFF image will be saved
            string outputPath = "output.tiff";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Create ImageSaveOptions for TIFF format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);

            // Set compression to none
            options.Compression = Compression.None;

            // Set background color (optional)
            options.BackgroundColor = Color.White;

            // Set custom DPI to 150
            options.HorizontalResolution = 150;
            options.VerticalResolution = 150;

            // Convert HTML to TIFF using the configured options
            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}