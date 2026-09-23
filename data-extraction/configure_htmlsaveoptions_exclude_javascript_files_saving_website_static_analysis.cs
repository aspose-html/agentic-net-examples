// Configure HTMLSaveOptions to exclude JavaScript files when saving a website for static analysis.

using System;

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string url = "https://www.example.com";
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url);
                Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
                options.ResourceHandlingOptions.JavaScript = Aspose.Html.Saving.ResourceHandling.Embed;
                string outputPath = "saved_website.html";
                document.Save(outputPath, options);
                Console.WriteLine("Website saved successfully to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}