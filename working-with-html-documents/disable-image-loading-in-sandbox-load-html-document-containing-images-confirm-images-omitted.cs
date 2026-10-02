// Disable image loading in sandbox, load an HTML document containing images, and confirm images are omitted.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlPath = "sample.html";
                string htmlContent = "<html><body><h1>Test</h1><img src='https://example.com/image.jpg' alt='test'/></body></html>";
                File.WriteAllText(htmlPath, htmlContent);

                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                configuration.Security |= Aspose.Html.Sandbox.Images;

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
                {
                    HTMLCollection images = document.GetElementsByTagName("img");
                    Console.WriteLine($"Number of img elements after sandbox: {images.Length}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}