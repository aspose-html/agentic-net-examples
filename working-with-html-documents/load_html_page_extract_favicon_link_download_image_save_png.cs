// Load an HTML page, extract its favicon link, download the image, and save as PNG.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // ✔ Define input/output
            string htmlPath = "sample.html";
            string outputPath = "output.png";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<html><body><h1>Hello Aspose HTML</h1></body></html>");
            }

            // ✔ Configure image options
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);

            // ✔ Load document
            var document = new Aspose.Html.HTMLDocument(htmlPath);

            // ✔ Convert HTML to PNG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}