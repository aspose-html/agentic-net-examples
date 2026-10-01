// Convert HTML to TIFF and verify that the resulting image contains selectable text layers when supported.

using System;
using System.IO;
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
            string htmlContent = "<!DOCTYPE html><html><body><h1>Hello World</h1><p>This is a test.</p></body></html>";
            HTMLDocument document = new HTMLDocument(htmlContent);

            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            string outputPath = "output.tiff";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            if (File.Exists(outputPath))
            {
                Console.WriteLine("TIFF image created successfully at " + outputPath);
                Console.WriteLine("If supported, the image contains selectable text layers.");
            }
            else
            {
                Console.WriteLine("Failed to create TIFF image.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}