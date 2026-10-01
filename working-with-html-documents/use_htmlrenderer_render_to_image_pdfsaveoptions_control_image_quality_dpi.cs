// Use HtmlRenderer.RenderToImage with PdfSaveOptions to control image quality and DPI.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a minimal HTML file
            string htmlPath = "input.html";
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            string outputPath = "output.jpg";

            // Configure image save options with DPI
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Convert HTML to JPEG image
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}