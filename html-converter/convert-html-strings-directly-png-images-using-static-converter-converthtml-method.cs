// Convert HTML strings directly to PNG images using the static Converter.ConvertHTML method.

using System;

namespace HTMLToPngExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string html = "<html><body><h1>Hello, World!</h1></body></html>";
                string baseUri = "about:blank";
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                string outputPath = "output.png";

                Aspose.Html.Converters.Converter.ConvertHTML(html, baseUri, options, outputPath);

                Console.WriteLine("Conversion completed. Image saved to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}