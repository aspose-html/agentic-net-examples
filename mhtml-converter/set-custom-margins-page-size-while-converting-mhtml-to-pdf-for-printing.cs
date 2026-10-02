// Set custom margins and page size in PdfSaveOptions while converting MHTML to PDF for printing.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Input MHTML file and output PDF file paths
            string mhtmlPath = "sample.mht";
            string pdfPath = "output.pdf";

            // Create a minimal MHTML file if it does not exist
            if (!File.Exists(mhtmlPath))
            {
                File.WriteAllText(mhtmlPath, @"MIME-Version: 1.0
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000""

------=_NextPart_000_0000
Content-Type: text/html; charset=""utf-8""

<html><body><h1>Hello, Aspose.HTML!</h1></body></html>
------=_NextPart_000_0000--");
            }

            // Set up PDF save options with custom page size and margins
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // A4 size in points (1 point = 1/72 inch)
            Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(595, 842);
            // 0.5 inch margins (36 points)
            Aspose.Html.Drawing.Margin pageMargin = new Aspose.Html.Drawing.Margin(36, 36, 36, 36);
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, pageMargin);
            options.PageSetup.AnyPage = page;

            // Convert MHTML to PDF using the configured options
            using (Stream stream = File.OpenRead(mhtmlPath))
            {
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, pdfPath);
            }

            Console.WriteLine("Conversion completed successfully. PDF saved to: " + pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}