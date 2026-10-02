// Convert an HTML document located at a URL to XPS format using a single‑line Converter method.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string sourceUrl = "https://example.com/sample.html";
            string outputPath = "sample.xps";
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(sourceUrl, "", options, outputPath);
            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}