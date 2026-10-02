// Apply CSS media type “screen” in ImageSaveOptions before converting HTML to TIFF to respect screen styles.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlPath = "sample.html";
            string outputPath = "output.tiff";

            if (!System.IO.File.Exists(htmlPath))
            {
                System.IO.File.WriteAllText(htmlPath,
                    "<!DOCTYPE html><html><head><style>" +
                    "@media screen { body { background: #ff0; } } " +
                    "@media print { body { background: #0f0; } }" +
                    "</style></head><body><h1>Hello World</h1></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            options.Css.MediaType = Aspose.Html.Rendering.MediaType.Screen;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            Console.WriteLine("Conversion completed: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}