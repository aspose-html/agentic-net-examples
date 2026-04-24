// Download icon data synchronously using WebClient for each resolved icon URL resource.

using System;
using System.IO;
using System.Net;
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
            // URL of the page containing icons
            string pageUrl = "https://example.com";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(pageUrl);

            // Get all <link> elements
            HTMLCollection links = document.GetElementsByTagName("link");

            // Directory to save downloaded icons
            string outputDir = "icons";
            Directory.CreateDirectory(outputDir);

            using (WebClient webClient = new WebClient())
            {
                for (int i = 0; i < links.Length; i++)
                {
                    Element linkElement = (Element)links[i];
                    // Consider only elements with rel containing "icon"
                    string rel = linkElement.GetAttribute("rel");
                    if (string.IsNullOrEmpty(rel) || !rel.ToLower().Contains("icon"))
                        continue;

                    string href = linkElement.GetAttribute("href");
                    if (string.IsNullOrEmpty(href))
                        continue;

                    // Resolve relative URL to absolute URL
                    Url iconUrl = new Url(href, document.BaseURI);
                    string urlString = iconUrl.ToString();

                    // Download icon data synchronously
                    byte[] iconBytes = webClient.DownloadData(urlString);

                    // Determine file name and save path
                    string fileName = Path.GetFileName(urlString);
                    if (string.IsNullOrEmpty(fileName))
                        fileName = $"icon_{i}.ico";

                    string savePath = Path.Combine(outputDir, fileName);
                    File.WriteAllBytes(savePath, iconBytes);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}