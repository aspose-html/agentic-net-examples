// Render HTML to PNG with transparent background by adjusting ImageSaveOptions background color.

using System;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define HTML content and output path
            string htmlContent = "<html><body style=\"background:transparent;\"><h1>Hello, World!</h1></body></html>";
            string baseUri = "about:blank";
            string outputPath = "output.png";

            // Load HTML document from string
            HTMLDocument document = new HTMLDocument(htmlContent, baseUri);

            // Configure image save options with transparent background
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
            options.BackgroundColor = Color.Transparent;

            // Convert HTML to PNG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}