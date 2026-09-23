// Save a website while preserving the original folder structure by setting appropriate HTMLSaveOptions.

using System;
using Aspose.Html;
using Aspose.Html.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // URL of the website to be saved
            string pageUrl = "https://example.com";

            // Output file path (resources will be saved in a subfolder)
            string outputPath = "saved_website.html";

            // Load the web page
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(pageUrl);

            // Configure save options to preserve original folder structure
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
            options.ResourceHandlingOptions.MaxHandlingDepth = 10;
            options.ResourceHandlingOptions.PageUrlRestriction = Aspose.Html.Saving.UrlRestriction.SameHost;

            // Save the website with the specified options
            document.Save(outputPath, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}