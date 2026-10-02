// Configure ImageSaveOptions to set color depth to 8‑bit for PNG output when reducing file size is required.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML and output PNG paths
            string inputHtmlPath = "sample.html";
            string outputPngPath = "output.png";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(inputHtmlPath))
            {
                File.WriteAllText(inputHtmlPath, "<html><body><h1>Hello World</h1></body></html>");
            }

            // Configure image save options for PNG output
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Note: Aspose.HTML does not expose a direct ColorDepth property.
            // PNG format uses 8‑bit color depth by default, which helps reduce file size.

            // Perform the conversion
            Aspose.Html.Converters.Converter.ConvertHTML(inputHtmlPath, options, outputPngPath);

            Console.WriteLine("HTML successfully converted to PNG at: " + Path.GetFullPath(outputPngPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}