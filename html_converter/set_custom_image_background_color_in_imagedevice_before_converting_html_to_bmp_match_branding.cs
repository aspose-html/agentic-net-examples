// Set custom image background color in ImageDevice before converting HTML to BMP to match branding.

using System;
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
            string documentPath = "input.html";
            string outputPath = "output.bmp";

            HTMLDocument document = new HTMLDocument(documentPath);
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
            options.UseAntialiasing = false;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = Color.FromArgb(255, 0, 120, 215);

            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}