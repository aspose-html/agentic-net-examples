// Use a CSS selector to find all list items within unordered lists and extract their text.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><ul><li>Item 1</li><li>Item 2</li></ul><ul><li>Item A</li></ul></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank"))
            {
                var elements = document.QuerySelectorAll("ul li");
                foreach (Aspose.Html.HTMLElement element in elements)
                {
                    Console.WriteLine(element.InnerHTML);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}