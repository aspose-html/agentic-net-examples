// Configure ResourceHandlingOptions to restrict saved resources to the same domain as the source page.

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string sourceUrl = "https://example.com";
            string outputPath = "output.html";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourceUrl);
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
            options.ResourceHandlingOptions.MaxHandlingDepth = 5;
            options.ResourceHandlingOptions.PageUrlRestriction = Aspose.Html.Saving.UrlRestriction.SameHost;
            document.Save(outputPath, options);

            System.Console.WriteLine("Document saved successfully to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}