// Select all paragraph elements using a CSS selector and iterate through them to extract plain text.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><p>First paragraph.</p><div><p>Second paragraph.</p></div></body></html>";
            string baseUri = "http://example.com/";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, baseUri);
            var paragraphs = document.QuerySelectorAll("p");
            foreach (Aspose.Html.HTMLElement element in paragraphs)
            {
                Console.WriteLine(element.TextContent);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}