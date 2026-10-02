// Convert HTML to BMP format while preserving CSS styles.

using System;
using System.IO;

namespace HTMLToBmpExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.bmp");

                if (!File.Exists(inputPath))
                {
                    string html = "<!DOCTYPE html><html><head><style>body{font-family:Arial; color:#333;}</style></head><body><h1>Hello, BMP!</h1><p>This is a sample HTML to BMP conversion.</p></body></html>";
                    File.WriteAllText(inputPath, html);
                }

                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                options.UseAntialiasing = false;
                options.HorizontalResolution = 96;
                options.VerticalResolution = 96;
                options.BackgroundColor = System.Drawing.Color.Beige;

                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

                Console.WriteLine("Conversion completed. BMP saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}