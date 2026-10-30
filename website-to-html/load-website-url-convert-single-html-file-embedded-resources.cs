// Load a website URL and convert it to a single HTML file with embedded resources.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string url = "https://example.com";
            string outputPath = "output.html";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url))
            {
                Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
                options.ResourceHandlingOptions.JavaScript = Aspose.Html.Saving.ResourceHandling.Embed;
                document.Save(outputPath, options);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}