// Render HTML email templates to PNG with a transparent background for use in marketing assets.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body style='background:transparent;'><h1 style='color:#ff0000;'>Hello, World!</h1></body></html>";
            string baseUri = "about:blank";

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.BackgroundColor = System.Drawing.Color.Transparent;

            string outputPath = "email_template.png";

            Aspose.Html.Converters.Converter.ConvertHTML(html, baseUri, options, outputPath);

            Console.WriteLine($"PNG image saved to {Path.GetFullPath(outputPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}