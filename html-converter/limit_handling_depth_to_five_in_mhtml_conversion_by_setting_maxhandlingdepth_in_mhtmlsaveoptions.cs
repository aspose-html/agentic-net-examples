// Limit handling depth to five in MHTML conversion by setting MaxHandlingDepth in MHTMLSaveOptions.

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
            string baseUri = "http://example.com";
            string outputPath = "output.mhtml";

            Aspose.Html.Saving.MHTMLSaveOptions options = new Aspose.Html.Saving.MHTMLSaveOptions();
            options.ResourceHandlingOptions.MaxHandlingDepth = 5;

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);

            System.Console.WriteLine("MHTML file saved to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}