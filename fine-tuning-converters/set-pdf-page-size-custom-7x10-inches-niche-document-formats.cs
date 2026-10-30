// Set PdfRenderingOptions.PageSize to custom dimensions of 7 by 10 inches for niche document formats.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare HTML content
            string htmlContent = "<html><body><h1>Custom Size PDF</h1></body></html>";
            Aspose.Html.Url baseUri = new Aspose.Html.Url("about:blank");
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            // Create PDF save options with custom page size (7in x 10in)
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(
                Aspose.Html.Drawing.Length.FromInches(7),
                Aspose.Html.Drawing.Length.FromInches(10));

            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize);
            options.PageSetup.AnyPage = page;

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, "custom_size.pdf");

            Console.WriteLine("PDF generated at custom_size.pdf");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}