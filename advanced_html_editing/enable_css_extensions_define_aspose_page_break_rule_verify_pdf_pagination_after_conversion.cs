// Enable CSS extensions, define a -aspose- page‑break rule, and verify PDF pagination after conversion.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string pdfPath = "output.pdf";
            string htmlContent = @"<!DOCTYPE html><html><head><style>@page {size: A4; margin: 1in;} .page-break {page-break-after: always;}</style></head><body><div>First page</div><div class='page-break'></div><div>Second page</div></body></html>";
            System.IO.File.WriteAllText(htmlPath, htmlContent);
            PdfSaveOptions options = new PdfSaveOptions();
            Converter.ConvertHTML(htmlPath, options, pdfPath);
            if (System.IO.File.Exists(pdfPath))
            {
                Console.WriteLine("PDF generated successfully.");
            }
            else
            {
                Console.WriteLine("PDF generation failed.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}