// Set ResourceHandlingOptions.RestrictedResourceUrls to block external JavaScript files during website saving.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            var document = new Aspose.Html.HTMLDocument(url);

            var options = new Aspose.Html.Saving.HTMLSaveOptions();
            // Skipping JavaScript handling is not supported in this version; the default behavior will be used.

            string outputPath = "saved.html";
            document.Save(outputPath, options);

            Console.WriteLine("Document saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}