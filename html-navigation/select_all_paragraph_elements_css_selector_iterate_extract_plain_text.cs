// Select all paragraph elements using a CSS selector and iterate through them to extract plain text.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string baseUrl = "http://example.com/";
            string html = "<html><body><p>First paragraph.</p><div><p>Second paragraph.</p></div></body></html>";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(baseUrl, html);
            var elements = document.QuerySelectorAll("p");

            foreach (Aspose.Html.HTMLElement element in elements)
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