// Set the maximum crawl depth for linked pages when converting an entire website to HTML.

using System;
using Aspose.Html;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // URL of the website to convert
            string url = "https://example.com";

            // Desired maximum crawl depth for linked pages
            int maxDepth = 2;

            // Path where the resulting HTML file will be saved
            string outputPath = "output.html";

            // Load the website into an HTMLDocument
            HTMLDocument document = new HTMLDocument(url);

            // Configure save options with the specified maximum handling depth
            HTMLSaveOptions options = new HTMLSaveOptions();
            options.ResourceHandlingOptions.MaxHandlingDepth = maxDepth;

            // Save the document to a local HTML file using the configured options
            document.Save(outputPath, options);
        }
        catch (Exception ex)
        {
            // Output any errors that occur during the conversion process
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}