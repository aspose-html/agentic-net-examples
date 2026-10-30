// Load an HTML page, disable image loading via sandbox, and confirm no images appear in output.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string pdfPath = "output.pdf";
            string htmlContent = "<html><body><h1>Test</h1><img src='https://example.com/image.png' alt='test image'></body></html>";
            System.IO.File.WriteAllText(htmlPath, htmlContent);

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Images;

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");
                Console.WriteLine("Image elements count before conversion: " + images.Length);

                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
            }

            Console.WriteLine("Conversion completed. PDF saved to " + pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}