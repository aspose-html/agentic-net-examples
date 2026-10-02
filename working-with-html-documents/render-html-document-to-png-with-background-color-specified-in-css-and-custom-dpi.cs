// Render an HTML document to PNG with a background color specified in CSS and custom DPI.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><style>body { background-color: bisque; }</style></head><body><h1>Hello, Aspose!</h1></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.BackgroundColor = System.Drawing.Color.Bisque;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            string outputPath = "output.png";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            Console.WriteLine("HTML rendered to PNG successfully: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}