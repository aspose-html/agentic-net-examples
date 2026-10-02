// Save a website with ResourceHandlingOptions.MaxHandlingDepth set to zero to capture only the entry page.

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url);
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
            options.ResourceHandlingOptions.MaxHandlingDepth = 0;
            string outputPath = "saved_page.html";
            document.Save(outputPath, options);
            System.Console.WriteLine("Page saved to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}