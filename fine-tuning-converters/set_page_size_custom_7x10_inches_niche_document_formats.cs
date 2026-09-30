// Set PdfRenderingOptions.PageSize to custom dimensions of 7 by 10 inches for niche document formats.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello, PDF!</h1></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);

            // Define custom page size and margin
            Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(
                Aspose.Html.Drawing.Length.FromInches(7f),
                Aspose.Html.Drawing.Length.FromInches(10f));

            Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(0, 0, 0, 0);
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, margin);

            // Configure PDF save options
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.PageSetup.AnyPage = page;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = System.Drawing.Color.AliceBlue;
            options.JpegQuality = 90;

            // Output file path
            string outputPath = Path.Combine(Environment.CurrentDirectory, "custom_page.pdf");

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}