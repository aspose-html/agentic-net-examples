// Configure HTMLSaveOptions to exclude JavaScript files when saving a website for static analysis.

class Program
{
    static void Main()
    {
        try
        {
            string inputUrl = "https://example.com";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputUrl);
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
            options.ResourceHandlingOptions.JavaScript = Aspose.Html.Saving.ResourceHandling.Embed;
            string outputPath = "output.html";
            document.Save(outputPath, options);
            System.Console.WriteLine("Website saved with JavaScript resources embedded.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}