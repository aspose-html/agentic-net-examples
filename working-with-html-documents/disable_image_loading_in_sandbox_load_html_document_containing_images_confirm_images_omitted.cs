// Disable image loading in sandbox, load an HTML document containing images, and confirm images are omitted.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML containing an image
            string htmlPath = "sample.html";
            string pdfPath = "output.pdf";
            string htmlContent = "<html><body><h1>Test Document</h1><img src='https://example.com/image.jpg' alt='Sample Image'/></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Create configuration and disable image loading via sandbox
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Images;

            // Load the HTML document with the sandbox configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                // Verify that img elements exist in the DOM (they are present but not loaded)
                Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");
                Console.WriteLine("Number of <img> elements in the document: " + images.Length);

                // Convert the document to PDF; images will be omitted due to sandbox settings
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
            }

            Console.WriteLine("PDF generated at '" + pdfPath + "' with images disabled.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}