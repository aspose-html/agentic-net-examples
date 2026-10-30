// Convert HTML to BMP format while preserving CSS styles.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                string htmlContent = "<!DOCTYPE html><html><head><style>body {font-family:Arial; color:#333;}</style></head><body><h1>Hello, Aspose.HTML!</h1><p>This is a sample HTML to BMP conversion.</p></body></html>";
                File.WriteAllText(inputPath, htmlContent);
            }

            HTMLDocument document = new HTMLDocument(inputPath);
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
            options.UseAntialiasing = false;
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;
            options.BackgroundColor = Color.Beige;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            Console.WriteLine("Conversion completed. Output saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}