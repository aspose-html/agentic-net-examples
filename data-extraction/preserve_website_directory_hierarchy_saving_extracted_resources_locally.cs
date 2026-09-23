// Preserve the original website directory hierarchy when saving extracted resources locally.

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
            string url = "https://example.com";
            string outputFile = "output/example.html";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputFile));

            // Load the HTML document from the URL
            HTMLDocument document = new HTMLDocument(url);

            // Configure save options to preserve resource hierarchy
            HTMLSaveOptions options = new HTMLSaveOptions();
            options.ResourceHandlingOptions.MaxHandlingDepth = 10;
            options.ResourceHandlingOptions.PageUrlRestriction = UrlRestriction.SameHost;

            // Save the document along with its resources
            document.Save(outputFile, options);

            Console.WriteLine("HTML saved successfully to " + outputFile);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}