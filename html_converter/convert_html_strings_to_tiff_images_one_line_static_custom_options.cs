// Convert HTML strings directly to TIFF images using one‑line static conversion with custom options.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using System.Drawing;
using Aspose.Html.Converters;

namespace HtmlToTiffExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string html = "<html><body><h1>Hello, TIFF!</h1></body></html>";
                string baseUri = ".";
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
                options.Compression = Compression.None;
                options.BackgroundColor = Color.White;
                options.HorizontalResolution = 150;
                options.VerticalResolution = 150;
                Converter.ConvertHTML(html, baseUri, options, "output.tiff");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}