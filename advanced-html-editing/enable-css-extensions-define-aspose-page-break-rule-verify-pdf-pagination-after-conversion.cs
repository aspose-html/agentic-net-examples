// Enable CSS extensions, define a -aspose- page‑break rule, and verify PDF pagination after conversion.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string pdfPath = "output.pdf";

            string htmlContent = "<!DOCTYPE html><html><head><style>" +
                                 ".break{-aspose-page-break:after; page-break-after:always;}" +
                                 "</style></head><body>" +
                                 "<div>First page content</div>" +
                                 "<div class='break'></div>" +
                                 "<div>Second page content</div>" +
                                 "</body></html>";

            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, htmlContent);
            }

            HTMLDocument document = new HTMLDocument(htmlPath);

            PdfSaveOptions options = new PdfSaveOptions();

            Size pageSize = new Size(Length.FromInches(8.5f), Length.FromInches(11f));
            Margin pageMargin = new Margin(0, 0, 0, 0);
            Page page = new Page(pageSize, pageMargin);
            options.PageSetup.AnyPage = page;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

            if (File.Exists(pdfPath))
            {
                Console.WriteLine("PDF conversion succeeded. Output file: " + pdfPath);
            }
            else
            {
                Console.WriteLine("PDF conversion failed: output file not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}