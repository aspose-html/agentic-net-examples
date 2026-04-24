// Convert HTML to BMP format while preserving CSS styles.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

namespace HtmlToBmpExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Path to the source HTML file
                string htmlPath = "input.html";
                // Path for the output BMP file
                string bmpPath = "output.bmp";

                // Load the HTML document (CSS styles are preserved)
                HTMLDocument document = new HTMLDocument(htmlPath);

                // Set image save options to BMP format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

                // Convert the HTML document to a BMP image
                Converter.ConvertHTML(document, options, bmpPath);

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}