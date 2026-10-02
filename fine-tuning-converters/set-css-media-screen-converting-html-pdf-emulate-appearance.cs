// Set CSS media type to Screen when converting HTML to PDF to emulate on‑screen appearance.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string pdfPath = "output.pdf";

            if (!File.Exists(htmlPath))
            {
                string htmlContent = "<!DOCTYPE html><html><head><style>body {font-family:Arial;}</style></head><body><h1>Hello, World!</h1><p>This PDF is rendered with screen CSS media type.</p></body></html>";
                File.WriteAllText(htmlPath, htmlContent);
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.Css.MediaType = Aspose.Html.Rendering.MediaType.Screen;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

            Console.WriteLine("Conversion completed successfully. PDF saved to: " + Path.GetFullPath(pdfPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}