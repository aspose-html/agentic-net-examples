// Set CssOptions.MediaType to Print for XPS conversion to reflect printed media styling.

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><style>@media print { body { color: red; } }</style></head><body><p>Hello World</p></body></html>";

            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            var options = new Aspose.Html.Saving.XpsSaveOptions();

            string outputPath = "output.xps";

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            System.Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}