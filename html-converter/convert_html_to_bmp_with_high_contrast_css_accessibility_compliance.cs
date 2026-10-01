// Convert HTML to BMP ensuring high‑contrast mode is applied via CSS for accessibility compliance.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare HTML with high‑contrast CSS
            string htmlContent = "<!DOCTYPE html><html><head><style>body{background-color:#000;color:#fff;}</style></head><body><h1>High Contrast Example</h1><p>This is a sample paragraph.</p></body></html>";
            string documentPath = "sample.html";
            File.WriteAllText(documentPath, htmlContent);

            // Output BMP path
            string savePath = "output.bmp";

            // Load HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(documentPath);

            // Configure image save options
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
            options.UseAntialiasing = false;
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;
            options.BackgroundColor = System.Drawing.Color.Beige;

            // Convert HTML to BMP
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);

            Console.WriteLine("Conversion completed successfully. Output saved to " + savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}