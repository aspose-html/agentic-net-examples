// Extract breadcrumb navigation links by locating ordered list elements with specific class names.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                System.String html = "<html><body><ol class='breadcrumb'><li><a href='home.html'>Home</a></li><li><a href='section.html'>Section</a></li></ol></body></html>";
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank"))
                {
                    Aspose.Html.Collections.NodeList links = document.QuerySelectorAll("ol.breadcrumb a");
                    foreach (Aspose.Html.HTMLElement link in links)
                    {
                        System.String href = link.GetAttribute("href");
                        System.String text = link.TextContent != null ? link.TextContent.Trim() : System.String.Empty;
                        System.Console.WriteLine($"Text: {text}, Href: {href}");
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}