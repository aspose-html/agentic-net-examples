// Configure HTMLSaveOptions to exclude JavaScript files when saving a website for static analysis.

using System;
using Aspose.Html;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url);
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
            options.ResourceHandlingOptions.JavaScript = Aspose.Html.Saving.ResourceHandling.Ignore;
            string outputPath = "saved.html";
            document.Save(outputPath, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}