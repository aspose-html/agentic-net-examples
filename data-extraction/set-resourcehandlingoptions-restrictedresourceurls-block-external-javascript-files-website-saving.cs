// Set ResourceHandlingOptions.RestrictedResourceUrls to block external JavaScript files during website saving.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Input URL or file path
            string pageUrl = "https://example.com";

            // Load the web page
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(pageUrl);

            // Configure save options to restrict external resources
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
            options.ResourceHandlingOptions.PageUrlRestriction = Aspose.Html.Saving.UrlRestriction.SameHost;
            // Optional: limit handling depth
            options.ResourceHandlingOptions.MaxHandlingDepth = 5;

            // Output path
            string outputPath = Path.Combine(Environment.CurrentDirectory, "saved_page.html");

            // Save the document with the configured options
            document.Save(outputPath, options);

            Console.WriteLine("Page saved successfully to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}