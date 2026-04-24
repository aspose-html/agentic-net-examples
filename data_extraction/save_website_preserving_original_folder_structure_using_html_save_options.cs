// Save a website while preserving the original folder structure by setting appropriate HTMLSaveOptions.

using System;
using Aspose.Html;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            HTMLDocument document = new HTMLDocument(url);
            HTMLSaveOptions options = new HTMLSaveOptions();
            options.ResourceHandlingOptions.MaxHandlingDepth = 1;
            options.ResourceHandlingOptions.PageUrlRestriction = UrlRestriction.SameHost;
            string outputPath = "saved_page.html";
            document.Save(outputPath, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}