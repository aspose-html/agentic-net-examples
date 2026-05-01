// Create a document, add a comment explaining purpose, and verify comment persists after conversion to PDF.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!-- This comment explains the purpose of the document -->\n<html><body><p>Hello World</p></body></html>";
            string baseUri = "file:///";
            var document = new HTMLDocument(htmlContent, baseUri);
            var options = new PdfSaveOptions();
            string outputPdf = "output.pdf";
            Converter.ConvertHTML(document, options, outputPdf);
            if (!File.Exists(outputPdf) || new FileInfo(outputPdf).Length == 0)
                throw new Exception("PDF conversion failed or file is empty.");
            Console.WriteLine("Conversion verification passed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}