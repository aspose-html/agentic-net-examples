// Save an entire website to a directory while limiting resource depth to two levels using HTMLSaveOptions.

class Program
{
    static void Main()
    {
        try
        {
            string inputUrl = "https://example.com";
            string outputPath = "SavedWebsite";

            if (!System.IO.Directory.Exists(outputPath))
            {
                System.IO.Directory.CreateDirectory(outputPath);
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputUrl);
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
            options.ResourceHandlingOptions.MaxHandlingDepth = 2;

            document.Save(outputPath, options);
            System.Console.WriteLine("Website saved successfully to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}