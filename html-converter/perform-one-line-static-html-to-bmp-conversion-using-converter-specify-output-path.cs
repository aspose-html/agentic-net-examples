// Perform a one‑line static conversion of HTML string to BMP using Converter.ConvertHTML and specifying output path.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><h1>Hello, World!</h1></body></html>";
            var document = new Aspose.Html.HTMLDocument(html, "about:blank");
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
            string outputPath = "output.bmp";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            Console.WriteLine("Conversion completed: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}