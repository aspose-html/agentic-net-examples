// Convert HTML to BMP after applying a custom CSS stylesheet that changes layout before rendering.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head></head><body><div class='box'>Hello, Aspose.HTML!</div></body></html>";

            // Custom CSS to change layout
            string cssContent = ".box { width: 200px; height: 100px; background-color: lightgreen; margin: 20px; }";

            // Create HTML document from string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Create <style> element with custom CSS
            Aspose.Html.HTMLElement styleElement = (Aspose.Html.HTMLElement)document.CreateElement("style");
            styleElement.InnerHTML = cssContent;

            // Append the style element to <head>
            Aspose.Html.HTMLElement head = (Aspose.Html.HTMLElement)document.GetElementsByTagName("head")[0];
            head.AppendChild(styleElement);

            // Configure image save options for BMP
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
            options.UseAntialiasing = false;
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;
            options.BackgroundColor = System.Drawing.Color.Beige;

            // Define output path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.bmp");

            // Convert HTML to BMP
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}