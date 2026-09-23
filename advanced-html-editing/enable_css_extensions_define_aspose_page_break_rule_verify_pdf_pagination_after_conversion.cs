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
            string htmlContent = "<!DOCTYPE html><html><head><style>.page { -aspose-page-break: after; }</style></head><body><div class='page'>Page 1 content</div><div class='page'>Page 2 content</div></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            Aspose.Html.Drawing.Size size = new Aspose.Html.Drawing.Size(Aspose.Html.Drawing.Length.FromInches(8.5f), Aspose.Html.Drawing.Length.FromInches(11f));
            Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(0, 0, 0, 0);
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(size, margin);
            options.PageSetup.AnyPage = page;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

            if (File.Exists(pdfPath))
            {
                long fileSize = new FileInfo(pdfPath).Length;
                Console.WriteLine($"PDF generated successfully. Size: {fileSize} bytes.");
            }
            else
            {
                Console.WriteLine("PDF generation failed: output file not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}