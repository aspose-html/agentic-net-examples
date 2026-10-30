// Save an entire website to a directory while limiting resource depth to two levels using HTMLSaveOptions.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // URL of the website to save
            string url = "https://example.com";

            // Directory where the website will be saved
            string outputPath = "SavedSite";
            System.IO.Directory.CreateDirectory(outputPath);

            // Load the website
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url);

            // Configure save options with a maximum resource handling depth of 2
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
            options.ResourceHandlingOptions.MaxHandlingDepth = 2;

            // Save the website to the specified directory
            document.Save(outputPath, options);

            Console.WriteLine("Website saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}