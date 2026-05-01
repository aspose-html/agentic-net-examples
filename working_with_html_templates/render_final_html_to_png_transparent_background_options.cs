// Render the final HTML to PNG with transparent background using appropriate rendering options.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Image;
using System.Drawing;

namespace HtmlToPngTransparent
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string htmlPath = "input.html";
                string outputPath = "output.png";

                HTMLDocument document = new HTMLDocument(htmlPath);
                ImageRenderingOptions options = new ImageRenderingOptions();
                options.BackgroundColor = Color.Transparent;

                ImageDevice device = new ImageDevice(options, outputPath);
                document.RenderTo(device);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}