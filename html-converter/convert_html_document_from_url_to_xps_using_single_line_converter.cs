// Convert an HTML document located at a URL to XPS format using a single‑line Converter method.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string sourceUrl = "https://example.com/sample.html";
            string baseUrl = sourceUrl;
            string outputPath = "output.xps";

            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

            Aspose.Html.Converters.Converter.ConvertHTML(sourceUrl, baseUrl, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}