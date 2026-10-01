// Create a helper method that accepts a URL and destination path, then performs the download and save logic.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            string outputPath = "output.html";
            DownloadAndSave(url, outputPath);
            Console.WriteLine("Download and save completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void DownloadAndSave(string url, string destinationPath)
    {
        var document = new Aspose.Html.HTMLDocument(url);
        var options = new Aspose.Html.Saving.HTMLSaveOptions();
        options.ResourceHandlingOptions.JavaScript = Aspose.Html.Saving.ResourceHandling.Embed;
        document.Save(destinationPath, options);
    }
}