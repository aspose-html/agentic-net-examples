// Use PageUrlRestriction to allow only HTTPS URLs when saving a multi‑page website.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            string outputPath = "output.html";

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
                options.ResourceHandlingOptions.MaxHandlingDepth = 5;
                options.ResourceHandlingOptions.PageUrlRestriction = Aspose.Html.Saving.UrlRestriction.SameHost;

                document.Save(outputPath, options);
            }

            Console.WriteLine("Document saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}