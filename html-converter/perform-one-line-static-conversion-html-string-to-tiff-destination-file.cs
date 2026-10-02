// Perform a one‑line static conversion of HTML string to TIFF by providing ImageSaveOptions and destination file.

using System;

namespace HTMLToTiffExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlContent = "<html><body><h1>Hello, TIFF!</h1></body></html>";
                var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
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