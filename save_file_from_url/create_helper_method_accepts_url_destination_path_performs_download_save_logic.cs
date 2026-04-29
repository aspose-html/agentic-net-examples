// Create a helper method that accepts a URL and destination path, then performs the download and save logic.

using System;
using Aspose.Html;
using Aspose.Html.Saving;

namespace DownloadHtmlExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length < 2)
                {
                    Console.WriteLine("Usage: DownloadHtmlExample <url> <outputPath>");
                    return;
                }

                string url = args[0];
                string outputPath = args[1];

                DownloadAndSave(url, outputPath);
                Console.WriteLine("Download completed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void DownloadAndSave(string url, string outputPath)
        {
            // Load the web page from the specified URL
            HTMLDocument document = new HTMLDocument(url);

            // Configure save options to embed JavaScript resources
            HTMLSaveOptions options = new HTMLSaveOptions();
            options.ResourceHandlingOptions.JavaScript = ResourceHandling.Embed;

            // Save the document to the destination path with the configured options
            document.Save(outputPath, options);
        }
    }
}