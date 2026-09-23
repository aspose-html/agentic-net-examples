// Configure ResourceHandlingOptions to restrict saved resources to the same domain as the source page.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            string outputPath = "output.html";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url);
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
            options.ResourceHandlingOptions.MaxHandlingDepth = 5;
            options.ResourceHandlingOptions.PageUrlRestriction = Aspose.Html.Saving.UrlRestriction.SameHost;

            document.Save(outputPath, options);
            Console.WriteLine("Document saved successfully to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}