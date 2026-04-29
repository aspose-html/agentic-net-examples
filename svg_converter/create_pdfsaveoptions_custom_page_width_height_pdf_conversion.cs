// Create PdfSaveOptions with custom page width and height for PDF conversion.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

namespace PdfConversionExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlPath = "input.html";
                string pdfPath = "output.pdf";

                HTMLDocument document = new HTMLDocument(htmlPath);
                PdfSaveOptions options = new PdfSaveOptions();

                Size pageSize = new Size(Length.FromInches(8.5f), Length.FromInches(11f));
                Margin pageMargin = new Margin(0, 0, 0, 0);
                Page customPage = new Page(pageSize, pageMargin);

                options.PageSetup.AnyPage = customPage;

                Converter.ConvertHTML(document, options, pdfPath);
                Console.WriteLine("PDF conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}