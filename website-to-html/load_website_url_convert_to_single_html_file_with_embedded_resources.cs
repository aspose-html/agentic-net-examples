// Load a website URL and convert it to a single HTML file with embedded resources.

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string url = "https://example.com";
            string outputPath = "saved_page.html";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url);
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
            options.ResourceHandlingOptions.MaxHandlingDepth = 1;
            options.ResourceHandlingOptions.PageUrlRestriction = Aspose.Html.Saving.UrlRestriction.SameHost;
            document.Save(outputPath, options);
            System.Console.WriteLine("Website saved to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}