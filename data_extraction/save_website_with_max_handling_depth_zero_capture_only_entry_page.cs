// Save a website with ResourceHandlingOptions.MaxHandlingDepth set to zero to capture only the entry page.

using System;
using Aspose.Html;
using Aspose.Html.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // URL of the web page to be saved
            string url = "https://example.com";

            // Local file path where the page will be saved
            string outputPath = "saved.html";

            // Load the web page into an HTMLDocument
            HTMLDocument document = new HTMLDocument(url);

            // Create save options and limit resource handling depth to zero (only the entry page)
            HTMLSaveOptions options = new HTMLSaveOptions();
            options.ResourceHandlingOptions.MaxHandlingDepth = 0;

            // Save the document with the configured options
            document.Save(outputPath, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}