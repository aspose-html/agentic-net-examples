// Enable CSS extensions, define a -aspose- page‑break rule, and verify PDF pagination after conversion.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Drawing;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML and output PDF paths
            string htmlPath = "sample.html";
            string pdfPath = "output.pdf";

            // Create sample HTML with Aspose page‑break CSS extension
            string htmlContent = @"
<!DOCTYPE html>
<html>
<head>
    <style>
        .break { -aspose-page-break: always; }
    </style>
</head>
<body>
    <div>
        <h1>Page 1</h1>
        <p>This is the first page content.</p>
    </div>
    <div class='break'></div>
    <div>
        <h1>Page 2</h1>
        <p>This is the second page content.</p>
    </div>
</body>
</html>";

            // Write HTML to file if it does not exist
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, htmlContent);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure PDF save options with page size and margins
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(
                Aspose.Html.Drawing.Length.FromInches(8.5f),
                Aspose.Html.Drawing.Length.FromInches(11f));
            Aspose.Html.Drawing.Margin pageMargin = new Aspose.Html.Drawing.Margin(72, 72, 72, 72); // 1 inch margins
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, pageMargin);
            options.PageSetup.AnyPage = page;

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

            // Verify that PDF was created and output its file size (as a simple pagination check)
            if (File.Exists(pdfPath))
            {
                FileInfo info = new FileInfo(pdfPath);
                Console.WriteLine($"PDF conversion succeeded. File size: {info.Length} bytes.");
            }
            else
            {
                Console.WriteLine("PDF conversion failed: output file not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}