// Render HTML to PDF with custom page orientation set to Landscape and 0.5‑inch margins on all sides.

using System;

namespace HtmlToPdfExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string html = "<html><body><h1>Hello World</h1></body></html>";
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html);
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

                Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(11.69f),
                    Aspose.Html.Drawing.Length.FromInches(8.27f));

                Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(36, 36, 36, 36);

                Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, margin);

                options.PageSetup.AnyPage = page;

                string outputPath = "output.pdf";

                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                Console.WriteLine("PDF saved to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}