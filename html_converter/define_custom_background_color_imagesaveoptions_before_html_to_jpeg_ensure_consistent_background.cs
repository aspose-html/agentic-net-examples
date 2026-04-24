// Define custom background color in ImageSaveOptions before converting HTML to JPEG to ensure consistent background.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using System.Drawing;

namespace HtmlToJpeg
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Path to the source HTML file
                string htmlPath = "input.html";

                // Path where the JPEG image will be saved
                string outputPath = "output.jpg";

                // Load the HTML document
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

                // Create JPEG save options and set a custom background color
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                options.BackgroundColor = System.Drawing.Color.LightBlue;

                // Perform the conversion
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}