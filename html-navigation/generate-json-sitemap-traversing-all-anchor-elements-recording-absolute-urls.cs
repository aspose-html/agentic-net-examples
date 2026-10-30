// Generate a JSON sitemap by traversing all anchor elements and recording their absolute URLs.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body>" +
                                 "<a href=\"https://example.com/page1\">Page1</a>" +
                                 "<a href=\"/page2\">Page2</a>" +
                                 "<a href=\"page3.html\">Page3</a>" +
                                 "</body></html>";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                Aspose.Html.Collections.HTMLCollection anchorCollection = document.GetElementsByTagName("a");
                List<string> absoluteUrls = new List<string>();

                for (int i = 0; i < anchorCollection.Length; i++)
                {
                    Aspose.Html.Dom.Element anchor = anchorCollection[i];
                    string href = anchor.GetAttribute("href");
                    if (string.IsNullOrEmpty(href))
                        continue;

                    Aspose.Html.Url resolvedUrl = new Aspose.Html.Url(href, document.BaseURI);
                    absoluteUrls.Add(resolvedUrl.ToString());
                }

                string jsonSitemap = JsonSerializer.Serialize(absoluteUrls, new JsonSerializerOptions { WriteIndented = true });
                Console.WriteLine(jsonSitemap);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}