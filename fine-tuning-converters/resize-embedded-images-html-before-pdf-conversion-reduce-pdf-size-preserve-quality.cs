// Resize embedded images in HTML before PDF conversion to reduce final PDF size while preserving quality.

using System;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define HTML content with an embedded image
            string htmlContent = "<html><body><h1>Sample Document</h1><img src='https://via.placeholder.com/600' alt='sample'></body></html>";
            Url baseUri = new Url("about:blank");

            // Load HTML document
            HTMLDocument document = new HTMLDocument(htmlContent, baseUri);

            // Resize all embedded images
            for (int i = 0; i < document.Images.Length; i++)
            {
                HTMLElement img = (HTMLElement)document.Images[i];
                img.SetAttribute("width", "200");
                img.SetAttribute("height", "200");
            }

            // Configure PDF save options
            PdfSaveOptions options = new PdfSaveOptions();
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;
            options.BackgroundColor = Color.AliceBlue;

            // Convert to PDF
            string outputPath = "output.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}