// Save a website with ResourceHandlingOptions.MaxHandlingDepth set to zero to capture only the entry page.

using System;

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
            string outputPath = "output.html";
            document.Save(outputPath, options);
            Console.WriteLine("Saved entry page to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}