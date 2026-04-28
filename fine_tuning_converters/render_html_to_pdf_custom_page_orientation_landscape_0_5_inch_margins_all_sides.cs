// Render HTML to PDF with custom page orientation set to Landscape and 0.5‑inch margins on all sides.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

namespace HtmlToPdfExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlPath = "input.html";
                string pdfPath = "output.pdf";

                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

                Aspose.Html.Drawing.Size size = new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(11),
                    Aspose.Html.Drawing.Length.FromInches(8.5));

                Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(36, 36, 36, 36);

                Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(size, margin);
                options.PageSetup.AnyPage = page;

                Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}