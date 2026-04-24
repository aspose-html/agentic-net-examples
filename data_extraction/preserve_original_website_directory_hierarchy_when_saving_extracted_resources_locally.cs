// Preserve the original website directory hierarchy when saving extracted resources locally.

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

            // Local path where the HTML file will be saved
            string outputPath = "saved_page.html";

            // Load the website into an HTMLDocument
            HTMLDocument document = new HTMLDocument(url);

            // Configure save options to preserve directly linked resources
            HTMLSaveOptions options = new HTMLSaveOptions();
            options.ResourceHandlingOptions.MaxHandlingDepth = 1;

            // Save the document; resources are stored in an adjacent folder preserving hierarchy
            document.Save(outputPath, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}