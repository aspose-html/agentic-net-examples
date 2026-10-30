// Set A4 page size and one‑inch margins in PdfSaveOptions before converting HTML to PDF.

using System;

namespace HTMLToPdfExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string html = "<html><body><h1>Hello, PDF!</h1></body></html>";
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");

                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

                Aspose.Html.Drawing.Size size = new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(8.27),
                    Aspose.Html.Drawing.Length.FromInches(11.69));

                Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(
                    Aspose.Html.Drawing.Length.FromInches(1),
                    Aspose.Html.Drawing.Length.FromInches(1),
                    Aspose.Html.Drawing.Length.FromInches(1),
                    Aspose.Html.Drawing.Length.FromInches(1));

                Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(size, margin);
                options.PageSetup.AnyPage = page;

                string pdfPath = "output.pdf";

                Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

                Console.WriteLine("PDF conversion completed successfully. Saved to " + pdfPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during PDF conversion: " + ex.Message);
            }
        }
    }
}