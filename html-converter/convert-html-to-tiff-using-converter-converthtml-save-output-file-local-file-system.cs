// Convert HTML to TIFF format using Converter.ConvertHTML and save the output file to the local file system.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.html";
            string outputPath = "output.tiff";

            if (!File.Exists(sourcePath))
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(sourcePath, htmlContent);
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath);

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            options.Compression = Aspose.Html.Rendering.Image.Compression.None;
            options.BackgroundColor = Color.White;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. TIFF saved to: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}