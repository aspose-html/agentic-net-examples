// Save an entire website to a directory while limiting resource depth to two levels using HTMLSaveOptions.

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

            // Local file path where the main HTML file will be saved
            string outputPath = "saved_site.html";

            // Load the website into an HTMLDocument
            HTMLDocument document = new HTMLDocument(url);

            // Configure save options with a limited resource handling depth (2 levels)
            HTMLSaveOptions options = new HTMLSaveOptions();
            options.ResourceHandlingOptions.MaxHandlingDepth = 2;

            // Save the website with the configured options
            document.Save(outputPath, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}