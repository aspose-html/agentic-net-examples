// Generate a JSON sitemap by traversing all anchor elements and recording their absolute URLs.

using System;
using System.Collections.Generic;
using System.Text.Json;
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
            string html = "<html><body><a href=\"page1.html\">Page 1</a><a href=\"https://example.com/page2\">Page 2</a></body></html>";
            using (HTMLDocument document = new HTMLDocument(html, "http://localhost/"))
            {
                HTMLCollection anchors = document.GetElementsByTagName("a");
                List<string> urlList = new List<string>();
                for (int i = 0; i < anchors.Length; i++)
                {
                    Element link = anchors[i] as Element;
                    if (link == null) continue;
                    string href = link.GetAttribute("href");
                    if (string.IsNullOrEmpty(href)) continue;
                    Url absoluteUrl = new Url(href, document.BaseURI);
                    urlList.Add(absoluteUrl.ToString());
                }
                string json = JsonSerializer.Serialize(urlList, new JsonSerializerOptions { WriteIndented = true });
                Console.WriteLine(json);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}