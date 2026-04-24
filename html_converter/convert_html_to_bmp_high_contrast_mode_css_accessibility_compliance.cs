// Convert HTML to BMP ensuring high‑contrast mode is applied via CSS for accessibility compliance.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string documentPath = "input.html";
            string savePath = "output.bmp";

            // Load HTML document
            HTMLDocument document = new HTMLDocument(documentPath);

            // Inject high‑contrast CSS
            var headElements = document.GetElementsByTagName("head");
            if (headElements.Length > 0)
            {
                var head = headElements[0];
                var style = document.CreateElement("style");
                style.SetAttribute("type", "text/css");
                style.TextContent = "body { background-color: black; color: white; } a { color: yellow; }";
                head.AppendChild(style);
            }

            // Configure image save options
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
            options.UseAntialiasing = false;
            options.HorizontalResolution = 350;
            options.VerticalResolution = 350;
            options.BackgroundColor = Color.Beige;

            // Convert HTML to BMP
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}