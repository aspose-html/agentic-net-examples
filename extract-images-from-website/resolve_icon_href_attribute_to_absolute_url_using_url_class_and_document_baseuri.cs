// Resolve each icon href attribute to an absolute URL using Url class and document BaseURI.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with icon link
            string html = "<!DOCTYPE html><html><head><link rel=\"icon\" href=\"/favicon.ico\"></head><body></body></html>";

            // Load HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html);

            // Get all <link> elements
            Aspose.Html.Collections.HTMLCollection links = document.GetElementsByTagName("link");

            // Iterate and resolve href attributes
            for (int i = 0; i < links.Length; i++)
            {
                Aspose.Html.Dom.Element linkElement = (Aspose.Html.Dom.Element)links[i];
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