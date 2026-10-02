// Set ImageSaveOptions.ImageFormat to Svg when converting Markdown to SVG to ensure correct output type.

using System;
using System.IO;

public class Program
{
    public static void Main()
    {
        try
        {
            // Sample HTML content (converted from markdown for demonstration)
            string html = "<html><body><h1>Hello World</h1><p>This is a <strong>markdown</strong> sample.</p></body></html>";
            string baseUri = "about:blank";

            // Output image path
            string outputPath = "output.png";

            // Configure image save options (PNG format)
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);

            // Convert HTML string to an image file
            Aspose.Html.Converters.Converter.ConvertHTML(html, baseUri, options, outputPath);

            Console.WriteLine("Conversion completed: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}