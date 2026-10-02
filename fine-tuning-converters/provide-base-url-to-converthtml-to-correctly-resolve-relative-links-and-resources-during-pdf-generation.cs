// Provide a base URL to ConvertHTML to correctly resolve relative links and resources during PDF generation.

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string html = "<html><body><img src='images/pic.png' alt='Sample Image'></body></html>";
                string baseUrl = "file:///C:/temp/";
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, baseUrl);
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                string outputPath = "output.pdf";
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                System.Console.WriteLine("PDF generated successfully at " + outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}