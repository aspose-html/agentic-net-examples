// Configure PdfSaveOptions to set a custom PDF version number for compatibility with older readers.

namespace AsposeHtmlPdfVersionExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlPath = "sample.html";
                string pdfPath = "output.pdf";

                System.IO.File.WriteAllText(htmlPath, "<!DOCTYPE html><html><body><h1>Hello, PDF!</h1></body></html>");

                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}