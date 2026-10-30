// Extract website icons defined with <link rel="icon"> and save them as .ico files.

using System;
using System.IO;
using System.Net.Http;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            // URL of the website to process
            string pageUrl = "https://example.com";

            // Load the HTML document from the URL
            HTMLDocument document = new HTMLDocument(pageUrl);

            // Get all <link> elements
            HTMLCollection links = document.GetElementsByTagName("link");

            // Prepare output directory
            string outputDir = "icons";
            Directory.CreateDirectory(outputDir);

            using (HttpClient httpClient = new HttpClient())
            {
                for (int i = 0; i < links.Length; i++)
                {
                    // Cast to Element to access attributes
                    Element linkElement = (Element)links[i];

                    // Check if rel attribute contains "icon"
                    string rel = linkElement.GetAttribute("rel");
                    if (string.IsNullOrEmpty(rel) || !rel.Contains("icon", StringComparison.OrdinalIgnoreCase))
                        continue;

                    // Get href attribute
                    string href = linkElement.GetAttribute("href");
                    if (string.IsNullOrEmpty(href))
                        continue;

                    // Resolve the URL relative to the document base URI
                    Url iconUrl = new Url(href, document.BaseURI);
                    string urlString = iconUrl.ToString();

                    // Download the icon bytes
                    byte[] iconBytes = httpClient.GetByteArrayAsync(urlString).GetAwaiter().GetResult();

                    // Determine file name and ensure .ico extension
                    string fileName = Path.GetFileName(urlString);
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(fileName);
                    string saveFileName = fileNameWithoutExt + ".ico";

                    // Save to output directory
                    string savePath = Path.Combine(outputDir, saveFileName);
                    File.WriteAllBytes(savePath, iconBytes);

                    Console.WriteLine($"Saved icon: {savePath}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}