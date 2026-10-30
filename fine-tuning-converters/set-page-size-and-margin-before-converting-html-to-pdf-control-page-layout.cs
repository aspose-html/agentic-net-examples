// Set PdfSaveOptions.PageSize and Margin before converting HTML to PDF to control page layout.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string htmlPath = "sample.html";
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            // Output PDF path
            string pdfPath = "output.pdf";

            // Load HTML document from file
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure PDF save options with custom page size and margins
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(
                Aspose.Html.Drawing.Length.FromInches(8.5),
                Aspose.Html.Drawing.Length.FromInches(11));

            Aspose.Html.Drawing.Margin pageMargin = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromInches(0.5),
                Aspose.Html.Drawing.Length.FromInches(0.5),
                Aspose.Html.Drawing.Length.FromInches(0.5),
                Aspose.Html.Drawing.Length.FromInches(0.5));

            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, pageMargin);
            options.PageSetup.AnyPage = page;

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

            Console.WriteLine("Conversion completed successfully. PDF saved to: " + Path.GetFullPath(pdfPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}