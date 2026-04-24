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
    static void Main(string[] args)
    {
        try
        {
            string pageUrl = "https://example.com"; // replace with target URL
            string outputDir = "icons";
            Directory.CreateDirectory(outputDir);

            HTMLDocument document = new HTMLDocument(pageUrl);
            HTMLCollection links = document.GetElementsByTagName("link");

            using (HttpClient httpClient = new HttpClient())
            {
                for (int i = 0; i < links.Length; i++)
                {
                    Element linkElement = (Element)links[i];
                    string rel = linkElement.GetAttribute("rel");
                    if (string.IsNullOrEmpty(rel) || !rel.Equals("icon", StringComparison.OrdinalIgnoreCase))
                        continue;

                    string href = linkElement.GetAttribute("href");
                    if (string.IsNullOrEmpty(href))
                        continue;

                    Url iconUrl = new Url(href, document.BaseURI);
                    string iconUrlString = iconUrl.ToString();

                    byte[] iconBytes = httpClient.GetByteArrayAsync(iconUrlString).GetAwaiter().GetResult();

                    string fileName = Path.GetFileName(iconUrlString);
                    if (string.IsNullOrEmpty(fileName) || !fileName.EndsWith(".ico", StringComparison.OrdinalIgnoreCase))
                        fileName = "favicon.ico";

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