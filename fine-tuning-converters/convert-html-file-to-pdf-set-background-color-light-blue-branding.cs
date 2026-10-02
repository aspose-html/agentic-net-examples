// Convert an HTML file to PDF and set background color to light blue for branding purposes.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

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
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, World!</h1></body></html>";
                File.WriteAllText(htmlPath, sampleHtml);
            }

            HTMLDocument document = new HTMLDocument(htmlPath);

            PdfSaveOptions options = new PdfSaveOptions();
            options.BackgroundColor = Color.LightBlue;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

            Console.WriteLine($"PDF saved to: {pdfPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}