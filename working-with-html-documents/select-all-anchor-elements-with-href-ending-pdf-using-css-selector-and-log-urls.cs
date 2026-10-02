// Select all anchor elements with href ending in ".pdf" using CSS selector and log URLs.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body>" +
                          "<a href='doc1.pdf'>Doc 1</a>" +
                          "<a href='http://example.com/file.pdf'>Doc 2</a>" +
                          "<a href='image.png'>Image</a>" +
                          "</body></html>";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");

            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("a[href$='.pdf']");

            foreach (Aspose.Html.HTMLElement element in elements)
            {
                string href = element.GetAttribute("href");
                Console.WriteLine(href);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}