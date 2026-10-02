// Add a nofollow attribute to external links to control search engine crawling.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><head><title>Sample</title></head><body><a href=\"https://example.com\">External</a> <a href=\"/local\">Local</a></body></html>";
            string baseUri = "about:blank";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri))
            {
                foreach (Aspose.Html.Dom.Element linkElement in document.Links)
                {
                    string href = linkElement.GetAttribute("href");
                    if (string.IsNullOrEmpty(href))
                        continue;
                    if (href.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                        href.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                    {
                        linkElement.SetAttribute("rel", "nofollow");
                    }
                }
                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine("Processed HTML saved to " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}