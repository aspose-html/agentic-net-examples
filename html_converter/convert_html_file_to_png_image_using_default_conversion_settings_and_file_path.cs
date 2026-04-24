// Convert an HTML file to a PNG image using default conversion settings and a file path.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

namespace HtmlToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string documentPath = "input.html";
                string savePath = "output.png";
                HTMLDocument document = new HTMLDocument(documentPath);
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
                Converter.ConvertHTML(document, options, savePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}