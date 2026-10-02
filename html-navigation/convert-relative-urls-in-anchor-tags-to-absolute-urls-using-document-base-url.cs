// Convert relative URLs in anchor tags to absolute URLs using the document’s base URL.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><head><base href=\"https://example.com/subdir/\"/></head><body><a href=\"page.html\">Link</a><a href=\"/root.html\">Root</a></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            foreach (Aspose.Html.Dom.Element linkElement in document.Links)
            {
                string href = linkElement.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;

                var absoluteUrl = new Aspose.Html.Url(href, document.BaseURI);
                linkElement.SetAttribute("href", absoluteUrl.ToString());
            }

            string resultHtml = document.DocumentElement.OuterHTML;
            Console.WriteLine(resultHtml);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}