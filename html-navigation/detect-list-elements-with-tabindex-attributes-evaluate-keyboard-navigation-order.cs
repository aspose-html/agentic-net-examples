// Detect and list all elements with tabindex attributes to evaluate keyboard navigation order.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><body><a href=\"#\" tabindex=\"1\">Link</a><button tabindex=\"2\">Button</button><div>Div</div></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank"))
            {
                Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("[tabindex]");
                foreach (Aspose.Html.HTMLElement element in elements)
                {
                    string tag = element.TagName;
                    string tabindex = element.GetAttribute("tabindex");
                    Console.WriteLine($"Tag: {tag}, TabIndex: {tabindex}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}