// Convert an HTML document located at a URL to XPS format using a single‑line Converter method.

class Program
{
    static void Main()
    {
        try
        {
            string documentUrl = "https://example.com";
            string outputPath = "output.xps";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(documentUrl);
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            System.Console.WriteLine("Conversion completed successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}