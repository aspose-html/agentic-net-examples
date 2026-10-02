// Load an HTML page, disable image loading via sandbox, and confirm no images appear in output.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string htmlContent = "<html><body><h1>Test</h1><img src='https://example.com/image.jpg' alt='test'></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            var configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Images;

            using (var document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                var images = document.GetElementsByTagName("img");
                Console.WriteLine($"Number of images loaded: {images.Length}");

                var options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, "output.pdf");
                Console.WriteLine("Conversion to PDF completed.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}