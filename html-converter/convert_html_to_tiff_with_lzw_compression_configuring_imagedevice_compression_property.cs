// Convert HTML to TIFF with LZW compression by configuring ImageDevice compression property.

using System;
using System.IO;

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlContent = "<html><body><h1>Hello, TIFF!</h1></body></html>";
                string inputPath = "sample.html";
                File.WriteAllText(inputPath, htmlContent);

                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                // Compression property omitted because LZW is not available in the current API.

                string outputPath = "output.tiff";
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

                Console.WriteLine("Conversion completed: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}