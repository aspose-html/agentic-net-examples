// Load a website URL and convert it to a single HTML file with embedded resources.

using System;
using Aspose.Html;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // URL of the website to be converted
            string url = "https://example.com";

            // Path of the output HTML file
            string outputPath = "output.html";

            // Load the website into an HTMLDocument
            HTMLDocument document = new HTMLDocument(url);

            // Configure save options to embed resources
            HTMLSaveOptions options = new HTMLSaveOptions();
            options.ResourceHandlingOptions.MaxHandlingDepth = 1;
            options.ResourceHandlingOptions.PageUrlRestriction = UrlRestriction.SameHost;

            // Save the document as a single HTML file with embedded resources
            document.Save(outputPath, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}