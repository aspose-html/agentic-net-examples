// Use ConvertHTML to transform an HTML string directly to PDF without creating an HTMLDocument instance.

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><h1>Hello, PDF!</h1></body></html>";
            string baseUri = "about:blank";
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            string outputPath = "output.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(html, baseUri, options, outputPath);
            System.Console.WriteLine("PDF saved to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}