// Set PdfRenderingOptions.PageSize to custom dimensions of 7 by 10 inches for niche document formats.

using System;
using System.IO;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlContent = "<html><body><h1>Hello, PDF!</h1></body></html>";
                Aspose.Html.Url baseUri = new Aspose.Html.Url("about:blank");
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

                Aspose.Html.Drawing.Size size = new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(7f),
                    Aspose.Html.Drawing.Length.FromInches(10f));

                Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(size);
                options.PageSetup.AnyPage = page;

                string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pdf");
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