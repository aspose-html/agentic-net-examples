// Configure ResourceHandlingOptions to restrict saved resources to the same domain as the source page.

using System;
using Aspose.Html;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string sourceUrl = "https://example.com";
            string outputPath = "saved_page.html";

            HTMLDocument document = new HTMLDocument(sourceUrl);
            HTMLSaveOptions options = new HTMLSaveOptions();
            options.ResourceHandlingOptions.MaxHandlingDepth = 1;
            options.ResourceHandlingOptions.PageUrlRestriction = UrlRestriction.SameHost;

            document.Save(outputPath, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}