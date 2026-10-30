// Disable image loading in sandbox, load an HTML document containing images, and confirm images are omitted.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string htmlContent = "<html><body><h1>Test</h1><img src='https://example.com/image.png' alt='test'></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security = Aspose.Html.Sandbox.None; // disable image loading

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                var images = document.Images;
                Console.WriteLine($"Number of images loaded: {images.Length}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}