// Convert an HTML string directly to a GIF image by passing the string and output path to Converter.ConvertHTML.

using System;
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
            string htmlContent = "<html><body><h1>Hello, GIF!</h1></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            string outputPath = "output.gif";

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("HTML has been successfully converted to GIF: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}