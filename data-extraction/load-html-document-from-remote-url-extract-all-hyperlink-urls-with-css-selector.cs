// Load an HTML document from a remote URL and extract all hyperlink URLs with a CSS selector.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Remote URL to load
            string pageUrl = "https://example.com";

            // Load the HTML document from the URL
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(pageUrl);

            // Select all anchor elements using a CSS selector
            foreach (Aspose.Html.Dom.Element element in document.QuerySelectorAll("a"))
            {
                string href = element.GetAttribute("href");
                if (!string.IsNullOrEmpty(href))
                {
                    // Resolve relative URLs against the document's base URI
                    Aspose.Html.Url resolvedUrl = new Aspose.Html.Url(href, document.BaseURI);
                    Console.WriteLine(resolvedUrl.ToString());
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}