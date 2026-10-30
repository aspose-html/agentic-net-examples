// Retrieve inner HTML of elements matched by XPath "//div[@class='content']" and log it.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string html = "<html><body><div class='content'>First</div><div class='content'>Second</div></body></html>";
            var document = new Aspose.Html.HTMLDocument(html, "about:blank");
            var nodes = document.QuerySelectorAll("div.content");
            foreach (Aspose.Html.HTMLElement element in nodes)
            {
                Console.WriteLine(element.InnerHTML);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}