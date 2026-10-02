// Generate PDF files from HTML templates, injecting dynamic data and using default unit conversion.

public class Program
{
    public static void Main()
    {
        try
        {
            string template = "<html><body><h1>Hello, {{name}}!</h1></body></html>";
            string htmlContent = template.Replace("{{name}}", "John Doe");
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            string outputPath = "output.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            System.Console.WriteLine("PDF generated at: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}