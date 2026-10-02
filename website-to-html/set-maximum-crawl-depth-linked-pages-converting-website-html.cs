// Set the maximum crawl depth for linked pages when converting an entire website to HTML.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string sourceUrl = "https://example.com";
            string outputPath = "output.html";

            var options = new Aspose.Html.Saving.HTMLSaveOptions();
            options.ResourceHandlingOptions.MaxHandlingDepth = 2;

            var document = new Aspose.Html.HTMLDocument(sourceUrl);
            document.Save(outputPath, options);
            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}