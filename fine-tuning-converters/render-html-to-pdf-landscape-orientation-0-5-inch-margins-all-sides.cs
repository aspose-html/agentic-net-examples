// Render HTML to PDF with custom page orientation set to Landscape and 0.5‑inch margins on all sides.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><h1>Hello, PDF!</h1></body></html>";
            var document = new Aspose.Html.HTMLDocument(html, "about:blank");
            var options = new Aspose.Html.Saving.PdfSaveOptions();

            var size = new Aspose.Html.Drawing.Size(
                Aspose.Html.Drawing.Length.FromInches(11),
                Aspose.Html.Drawing.Length.FromInches(8.5));

            var margin = new Aspose.Html.Drawing.Margin(36, 36, 36, 36);
            var page = new Aspose.Html.Drawing.Page(size, margin);
            options.PageSetup.AnyPage = page;

            string outputPath = "output.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            Console.WriteLine("PDF created successfully at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}