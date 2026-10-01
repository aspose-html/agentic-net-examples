// Convert an HTML file to a GIF image using default settings with a single method call.

using System;
using System.IO;

namespace HtmlToGifExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string htmlPath = "input.html";
                string outputPath = "output.gif";

                if (!File.Exists(htmlPath))
                {
                    File.WriteAllText(htmlPath, "<!DOCTYPE html><html><body><h1>Hello, World!</h1></body></html>");
                }

                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

                Console.WriteLine("Conversion completed successfully. Output saved to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}