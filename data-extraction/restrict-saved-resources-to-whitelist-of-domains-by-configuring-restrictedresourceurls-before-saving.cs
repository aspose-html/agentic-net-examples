// Restrict saved resources to a whitelist of domains by configuring RestrictedResourceUrls before saving.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with resources from two different domains
            string htmlContent = "<html><body>" +
                                 "<img src='https://example.com/image.png' alt='Allowed'>" +
                                 "<img src='https://other.com/other.png' alt='Blocked'>" +
                                 "</body></html>";

            // Load the HTML content (base URI is required for relative URLs)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Configure save options with resource handling
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
            options.ResourceHandlingOptions.MaxHandlingDepth = 5;
            options.ResourceHandlingOptions.PageUrlRestriction = Aspose.Html.Saving.UrlRestriction.SameHost;

            // Save the document; resources will be handled according to the configured options
            string outputPath = "output.html";
            document.Save(outputPath, options);

            Console.WriteLine($"Document saved to '{outputPath}' with resource handling options applied.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}