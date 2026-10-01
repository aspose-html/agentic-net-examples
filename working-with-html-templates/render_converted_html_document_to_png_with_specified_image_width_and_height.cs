// Render the converted HTML document to PNG with a specified image width and height.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // ✔ Define paths
            string htmlPath = "sample.html";
            string outputPath = "output.jpg";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<html><body><h1>Hello Aspose HTML</h1></body></html>");
            }

            // ✔ Configure image options
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // ✔ Load document
            var document = new Aspose.Html.HTMLDocument(htmlPath);

            // ✔ Convert to image
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine($"Conversion completed. Image saved to '{outputPath}'.");
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}