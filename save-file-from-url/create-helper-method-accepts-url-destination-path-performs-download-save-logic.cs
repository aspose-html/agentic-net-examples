// Create a helper method that accepts a URL and destination path, then performs the download and save logic.

using System;

public class Program
{
    public static void Main()
    {
        try
        {
            string url = "https://example.com";
            string outputPath = "example.html";
            DownloadAndSave(url, outputPath);
            Console.WriteLine($"Saved HTML from {url} to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void DownloadAndSave(string url, string outputPath)
    {
        var document = new Aspose.Html.HTMLDocument(url);
        var options = new Aspose.Html.Saving.HTMLSaveOptions();
        options.ResourceHandlingOptions.JavaScript = Aspose.Html.Saving.ResourceHandling.Embed;
        document.Save(outputPath, options);
    }
}