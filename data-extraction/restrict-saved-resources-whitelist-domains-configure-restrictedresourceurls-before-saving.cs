// Restrict saved resources to a whitelist of domains by configuring RestrictedResourceUrls before saving.

using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with resources from different domains
            string htmlContent = @"
                <html>
                    <head><title>Resource Whitelist Example</title></head>
                    <body>
                        <h1>Allowed Image</h1>
                        <img src='https://example.com/allowed.png' />
                        <h1>Disallowed Image</h1>
                        <img src='https://otherdomain.com/disallowed.png' />
                    </body>
                </html>";

            // Load HTML document from string (base URI is required)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Configure save options with resource handling
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
            options.ResourceHandlingOptions.MaxHandlingDepth = 5;
            options.ResourceHandlingOptions.PageUrlRestriction = Aspose.Html.Saving.UrlRestriction.SameHost;

            // Define output path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");

            // Save the document with the configured options
            document.Save(outputPath, options);

            Console.WriteLine("Document saved successfully to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}