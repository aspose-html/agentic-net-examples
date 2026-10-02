// Convert an HTML string to an MHTML file with MHTMLSaveOptions configured to limit handling depth.

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello, World!</h1></body></html>";
            string baseUri = "about:blank";
            string outputPath = "output.mhtml";

            Aspose.Html.Saving.MHTMLSaveOptions options = new Aspose.Html.Saving.MHTMLSaveOptions();
            options.ResourceHandlingOptions.MaxHandlingDepth = 5;

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);
            System.Console.WriteLine("Conversion completed. Output saved to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}