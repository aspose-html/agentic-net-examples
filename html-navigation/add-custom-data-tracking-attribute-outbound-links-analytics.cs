// Add a custom data‑tracking attribute to all outbound links for analytics purposes.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><a href=\"https://example.com\">External</a><a href=\"/local\">Local</a></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank"))
            {
                Aspose.Html.Collections.HTMLCollection anchors = document.GetElementsByTagName("a");
                for (int i = 0; i < anchors.Length; i++)
                {
                    Aspose.Html.HTMLElement link = (Aspose.Html.HTMLElement)anchors[i];
                    string href = link.GetAttribute("href");
                    if (!string.IsNullOrEmpty(href) && (href.StartsWith("http://") || href.StartsWith("https://")))
                    {
                        link.SetAttribute("data-tracking-id", System.Guid.NewGuid().ToString());
                    }
                }
                document.Save("output.html");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}