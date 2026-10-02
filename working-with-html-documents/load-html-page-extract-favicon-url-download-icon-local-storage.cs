// Load an HTML page, extract its favicon URL, download the icon to local storage.

using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Aspose.Html.Net;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            // Define paths
            string inputPath = "sample.html";
            string outputDir = "output";
            // Ensure output directory exists
            System.IO.Directory.CreateDirectory(outputDir);
            // Create a minimal HTML file with a favicon link if it does not exist
            if (!System.IO.File.Exists(inputPath))
            {
                string htmlContent = "<html><head><link rel=\"icon\" href=\"https://www.google.com/favicon.ico\" /></head><body></body></html>";
                System.IO.File.WriteAllText(inputPath, htmlContent);
            }

            // Load the HTML document
            using (HTMLDocument document = new HTMLDocument(inputPath))
            using (HttpClient httpClient = new HttpClient())
            {
                // Find link elements that define a favicon
                HTMLCollection links = document.GetElementsByTagName("link");
                string faviconUrlString = null;

                for (int i = 0; i < links.Length; i++)
                {
                    Element linkElement = (Element)links[i];
                    string rel = linkElement.GetAttribute("rel");
                    if (string.IsNullOrEmpty(rel) || !rel.ToLowerInvariant().Contains("icon"))
                        continue;

                    string href = linkElement.GetAttribute("href");
                    if (string.IsNullOrEmpty(href))
                        continue;

                    // Resolve the URL against the document's base URI
                    Url resolvedUrl = new Url(href, document.BaseURI);
                    faviconUrlString = resolvedUrl.ToString();
                    break; // Use the first found favicon
                }

                if (string.IsNullOrEmpty(faviconUrlString))
                {
                    Console.WriteLine("Favicon not found in the HTML document.");
                    return;
                }

                // Download the favicon
                byte[] iconBytes = await httpClient.GetByteArrayAsync(faviconUrlString);
                string fileName = System.IO.Path.GetFileName(faviconUrlString);
                if (string.IsNullOrEmpty(fileName))
                {
                    fileName = "favicon.ico";
                }
                string savePath = System.IO.Path.Combine(outputDir, fileName);
                System.IO.File.WriteAllBytes(savePath, iconBytes);
                Console.WriteLine($"Favicon saved to: {savePath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}