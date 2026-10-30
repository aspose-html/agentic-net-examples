// Resolve each icon href attribute to an absolute URL using Url class and document BaseURI.

using System;

public class Program
{
    public static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head><link rel=\"icon\" href=\"/favicon.ico\"><link rel=\"icon\" href=\"images/icon.png\"></head><body></body></html>";
            string baseUri = "https://example.com/";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, baseUri);
            Aspose.Html.Collections.HTMLCollection links = document.GetElementsByTagName("link");
            for (int i = 0; i < links.Length; i++)
            {
                Aspose.Html.Dom.Element linkElement = (Aspose.Html.Dom.Element)links[i];
                string rel = linkElement.GetAttribute("rel");
                if (rel == null || !rel.Equals("icon", StringComparison.OrdinalIgnoreCase))
                    continue;
                string href = linkElement.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;
                Aspose.Html.Url absoluteUrl = new Aspose.Html.Url(href, document.BaseURI);
                Console.WriteLine(absoluteUrl.ToString());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}