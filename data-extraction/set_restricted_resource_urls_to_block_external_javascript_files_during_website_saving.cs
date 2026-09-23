// Set ResourceHandlingOptions.RestrictedResourceUrls to block external JavaScript files during website saving.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            string outputPath = "saved_page.html";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url);
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
            options.ResourceHandlingOptions.JavaScript = Aspose.Html.Saving.ResourceHandling.Embed;

            document.Save(outputPath, options);
            Console.WriteLine("Page saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}