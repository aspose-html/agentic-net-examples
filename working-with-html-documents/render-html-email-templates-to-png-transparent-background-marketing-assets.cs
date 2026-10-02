// Render HTML email templates to PNG with a transparent background for use in marketing assets.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML email template
            string html = "<html><body style='font-family:Arial;'><h1>Hello, World!</h1><p>This is an email template.</p></body></html>";
            string baseUrl = "about:blank";

            // Configure image save options for PNG with transparent background
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.BackgroundColor = System.Drawing.Color.Transparent;

            // Output file path
            string outputPath = "email_template.png";

            // Convert HTML to PNG
            Aspose.Html.Converters.Converter.ConvertHTML(html, baseUrl, options, outputPath);

            Console.WriteLine("Conversion completed: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}