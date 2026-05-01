// Apply a DPI of 72 when rendering HTML to PNG for low‑resolution preview generation.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

namespace HtmlToPngPreview
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Path to the source HTML file
                string htmlPath = "sample.html";

                // Path where the PNG preview will be saved
                string outputPath = "preview.png";

                // Create ImageSaveOptions with PNG format and set DPI to 72
                var options = new ImageSaveOptions(ImageFormat.Png);
                options.HorizontalResolution = 72;
                options.VerticalResolution = 72;

                // Convert HTML to PNG using the specified options
                Converter.ConvertHTML(htmlPath, options, outputPath);
            }
            catch (Exception ex)
            {
                // Output any errors that occur during conversion
                Console.WriteLine(ex.Message);
            }
        }
    }
}