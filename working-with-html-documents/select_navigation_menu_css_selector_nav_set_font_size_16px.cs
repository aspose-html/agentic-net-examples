// Select the navigation menu using CSS selector "#nav" and set its font size to 16px.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string html = "<html><body><h1>Hello Aspose.HTML</h1></body></html>";

            // Create HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html))
            {
                // Define dimensions in pixels
                double columnWidthPixels = 200.0;
                double rowHeightPixels = 100.0;

                double columnWidthMillimeters = columnWidthPixels / 96.0 * 25.4;
                double rowHeightMillimeters = rowHeightPixels / 96.0 * 25.4;

                Console.WriteLine($"Column width: {{ {columnWidthPixels} }}px = {{ {columnWidthMillimeters:F2} }} mm");
                Console.WriteLine($"Row height: {{ {rowHeightPixels} }}px = {{ {rowHeightMillimeters:F2} }} mm");

                // Overall image size in pixels
                double widthPixels = 800.0;
                double heightPixels = 600.0;
                double widthMillimeters = widthPixels / 96.0 * 25.4;
                double heightMillimeters = heightPixels / 96.0 * 25.4;

                // Set up image rendering options
                Aspose.Html.Rendering.Image.ImageRenderingOptions options =
                    new Aspose.Html.Rendering.Image.ImageRenderingOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(
                        Aspose.Html.Drawing.Length.FromMillimeters(widthMillimeters),
                        Aspose.Html.Drawing.Length.FromMillimeters(heightMillimeters)));

                string outputPath = "output.jpg";

                // Render to image
                using (Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath))
                {
                    document.RenderTo(device);
                }

                Console.WriteLine($"Image saved to {Path.GetFullPath(outputPath)}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}