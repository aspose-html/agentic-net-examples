// Detect pagination controls by searching for links containing “next” or “previous” text.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><a href='page2.html'>Next</a> <a href='page1.html'>Previous</a> <a href='home.html'>Home</a></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html))
            {
                var paginationLinks = new System.Collections.Generic.List<string>();
                foreach (Aspose.Html.Dom.Element linkElement in document.Links)
                {
                    string href = linkElement.GetAttribute("href");
                    if (string.IsNullOrEmpty(href))
                        continue;

                    string text = linkElement.TextContent != null ? linkElement.TextContent.Trim() : string.Empty;
                    if (text.IndexOf("next", System.StringComparison.OrdinalIgnoreCase) >= 0 ||
                        text.IndexOf("previous", System.StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        paginationLinks.Add($"{text} -> {href}");
                    }
                }

                Console.WriteLine("Detected pagination links:");
                foreach (string item in paginationLinks)
                {
                    Console.WriteLine(item);
                }
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}