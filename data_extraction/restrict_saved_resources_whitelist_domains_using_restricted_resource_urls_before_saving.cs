// Restrict saved resources to a whitelist of domains by configuring RestrictedResourceUrls before saving.

using System;
using Aspose.Html;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // URL of the website to be saved
            string url = "https://example.com";

            // Path where the saved HTML file will be written
            string outputPath = "saved.html";

            // Load the web page into an HTMLDocument
            HTMLDocument document = new HTMLDocument(url);

            // Create save options
            HTMLSaveOptions options = new HTMLSaveOptions();

            // Limit resource handling depth to one level
            options.ResourceHandlingOptions.MaxHandlingDepth = 1;

            // Restrict saved resources to the same host as the source URL
            options.ResourceHandlingOptions.PageUrlRestriction = UrlRestriction.SameHost;

            // Save the document with the configured options
            document.Save(outputPath, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}