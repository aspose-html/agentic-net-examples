// Save an entire website to a directory while limiting resource depth to two levels using HTMLSaveOptions.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string url = "https://example.com";
            string outputPath = "SavedWebsite";

            // Ensure the output directory exists
            System.IO.Directory.CreateDirectory(outputPath);

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url);
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
            options.ResourceHandlingOptions.MaxHandlingDepth = 2;

            document.Save(outputPath, options);

            Console.WriteLine("Website saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}