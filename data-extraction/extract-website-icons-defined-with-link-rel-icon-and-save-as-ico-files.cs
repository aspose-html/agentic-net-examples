// Extract website icons defined with <link rel="icon"> and save them as .ico files.

using System;
using System.IO;
using System.Net.Http;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Input website URL
            string websiteUrl = "https://example.com";

            // Load the HTML document from the website
            HTMLDocument document = new HTMLDocument(websiteUrl);

            // Get all <link> elements
            HTMLCollection links = document.GetElementsByTagName("link");

            // Output directory for icons
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "icons");
            Directory.CreateDirectory(outputDir);

            using (HttpClient httpClient = new HttpClient())
            {
                for (int i = 0; i < links.Length; i++)
                {
                    Element linkElement = (Element)links[i];
                    string rel = linkElement.GetAttribute("rel");
                    if (string.IsNullOrEmpty(rel) || !rel.Contains("icon", StringComparison.OrdinalIgnoreCase))
                        continue;

                    string href = linkElement.GetAttribute("href");
                    if (string.IsNullOrEmpty(href))
                        continue;

                    // Resolve the icon URL relative to the document base URI
                    Url iconUrl = new Url(href, document.BaseURI);
                    string urlString = iconUrl.ToString();

                    // Download the icon data
                    byte[] iconBytes = httpClient.GetByteArrayAsync(urlString).GetAwaiter().GetResult();

                    // Determine file name and ensure .ico extension
                    string fileName = Path.GetFileName(urlString);
                    if (!fileName.EndsWith(".ico", StringComparison.OrdinalIgnoreCase))
                        fileName = Path.ChangeExtension(fileName, ".ico");

                    string savePath = Path.Combine(outputDir, fileName);
                    File.WriteAllBytes(savePath, iconBytes);
                }
            }

            Console.WriteLine("Icon extraction completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}