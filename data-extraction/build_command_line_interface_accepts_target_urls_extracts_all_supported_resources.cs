// Build a command‑line interface that accepts target URLs and extracts all supported resources.

using System;
using System.IO;
using System.Net.Http;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] targetUrls = args.Length > 0
                ? args
                : new string[] { "https://example.com" };

            using (HttpClient httpClient = new HttpClient())
            {
                foreach (string targetUrl in targetUrls)
                {
                    // Load the HTML document from the URL
                    HTMLDocument document = new HTMLDocument(targetUrl);

                    // Create a safe folder name for the URL
                    string folderName = targetUrl.Replace("://", "_").Replace("/", "_").Replace("?", "_").Replace("&", "_");
                    string outputDir = Path.Combine("ExtractedResources", folderName);
                    Directory.CreateDirectory(outputDir);

                    // Extract images
                    ExtractResources(document, "img", "src", httpClient, outputDir);

                    // Extract scripts
                    ExtractResources(document, "script", "src", httpClient, outputDir);

                    // Extract stylesheets
                    ExtractResources(document, "link", "href", httpClient, outputDir, (element) =>
                    {
                        string rel = element.GetAttribute("rel");
                        return string.Equals(rel, "stylesheet", StringComparison.OrdinalIgnoreCase);
                    });
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void ExtractResources(HTMLDocument document, string tagName, string attributeName, HttpClient httpClient, string outputDir, Func<Element, bool> filter = null)
    {
        HTMLCollection elements = document.GetElementsByTagName(tagName);
        for (int i = 0; i < elements.Length; i++)
        {
            Element element = (Element)elements[i];
            if (filter != null && !filter(element))
                continue;

            string src = element.GetAttribute(attributeName);
            if (string.IsNullOrEmpty(src))
                continue;

            // Resolve relative URLs against the document base URI
            Uri baseUri = new Uri(document.BaseURI);
            Uri resourceUri = new Uri(baseUri, src);
            string urlString = resourceUri.ToString();

            byte[] data = httpClient.GetByteArrayAsync(urlString).GetAwaiter().GetResult();
            string fileName = Path.GetFileName(resourceUri.LocalPath);
            if (string.IsNullOrEmpty(fileName))
                fileName = Guid.NewGuid().ToString();

            string savePath = Path.Combine(outputDir, fileName);
            File.WriteAllBytes(savePath, data);
        }
    }
}