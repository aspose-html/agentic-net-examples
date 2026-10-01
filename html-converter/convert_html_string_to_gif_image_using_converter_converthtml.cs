// Convert an HTML string directly to a GIF image by passing the string and output path to Converter.ConvertHTML.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><h1>Hello, World!</h1></body></html>";
            var document = new Aspose.Html.HTMLDocument(html);
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