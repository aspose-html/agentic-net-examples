// Load a website URL and convert it to a single HTML file with embedded resources.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputUrl = "https://example.com";
            string outputPath = "output.html";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputUrl))
            {
                Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
                options.ResourceHandlingOptions.MaxHandlingDepth = 5;
                options.ResourceHandlingOptions.PageUrlRestriction = Aspose.Html.Saving.UrlRestriction.SameHost;
                options.ResourceHandlingOptions.JavaScript = Aspose.Html.Saving.ResourceHandling.Embed;

                document.Save(outputPath, options);
            }

            System.Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}