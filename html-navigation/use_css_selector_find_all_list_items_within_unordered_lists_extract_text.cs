// Use a CSS selector to find all list items within unordered lists and extract their text.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string html = "<!DOCTYPE html><html><body><ul><li>Item 1</li><li>Item 2</li></ul><ul><li>Item A</li></ul></body></html>";
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "");
                Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("ul li");
                foreach (Aspose.Html.HTMLElement element in elements)
                {
                    System.Console.WriteLine(element.InnerHTML);
                }
            }
            catch (System.Exception ex)
            {
                System.Console.Error.WriteLine("Error: " + ex.Message);
            }
        }
    }
}