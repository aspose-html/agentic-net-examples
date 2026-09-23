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
            string websiteUrl = "https://example.com";
            HTMLDocument document = new HTMLDocument(websiteUrl);
            HTMLCollection links = document.GetElementsByTagName("link");
            string outputDir = "Icons";
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

                    Url iconUrl = new Url(href, document.BaseURI);
                    string urlString = iconUrl.ToString();

                    byte[] data = httpClient.GetByteArrayAsync(urlString).GetAwaiter().GetResult();

                    string fileName = Path.GetFileNameWithoutExtension(urlString) + ".ico";
                    string savePath = Path.Combine(outputDir, fileName);
                    File.WriteAllBytes(savePath, data);
                }
            }

            Console.WriteLine("Icon extraction completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}