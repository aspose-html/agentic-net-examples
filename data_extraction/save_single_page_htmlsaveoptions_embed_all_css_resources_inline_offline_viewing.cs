// Save a single page with HTMLSaveOptions that embed all CSS resources inline for offline viewing.

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
            HTMLDocument document = new HTMLDocument("https://example.com");

            // Configure save options to embed resources
            HTMLSaveOptions options = new HTMLSaveOptions();
            options.ResourceHandlingOptions.MaxHandlingDepth = -1; // handle all linked resources

            // Save the page with all CSS embedded inline
            document.Save("output.html", options);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}