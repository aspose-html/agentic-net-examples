// Set ResourceHandlingOptions.RestrictedResourceUrls to block external JavaScript files during website saving.

using System;
using Aspose.Html;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Load the web page
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("https://example.com");

            // Configure save options
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();

            // Restrict resource URLs to the same host (blocks external JavaScript files)
            options.ResourceHandlingOptions.ResourceUrlRestriction = Aspose.Html.Saving.UrlRestriction.SameHost;

            // Save the page locally
            document.Save("saved.html", options);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}