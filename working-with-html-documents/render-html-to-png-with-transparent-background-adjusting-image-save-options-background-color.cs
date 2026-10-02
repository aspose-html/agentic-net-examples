// Render HTML to PNG with transparent background by adjusting ImageSaveOptions background color.

using System;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML content
            string htmlContent = "<html><body style='margin:0;'><div style='width:200px;height:200px;background:rgba(255,0,0,0.5);'></div></body></html>";

            // Load HTML document from string
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Configure image save options for PNG with transparent background
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.BackgroundColor = System.Drawing.Color.Transparent;

            // Define output file path
            string outputPath = "output.png";

            // Convert HTML to PNG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}