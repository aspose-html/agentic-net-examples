// Configure ResourceHandlingOptions to restrict saved resources to the same domain as the source page.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string sourceUrl = "https://example.com";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourceUrl);

            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
            options.ResourceHandlingOptions.MaxHandlingDepth = 5;
            options.ResourceHandlingOptions.PageUrlRestriction = Aspose.Html.Saving.UrlRestriction.SameHost;

            string outputPath = "output.html";
            document.Save(outputPath, options);

            Console.WriteLine("Document saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}