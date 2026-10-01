// Detect and list all elements with tabindex attributes to evaluate keyboard navigation order.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><body>" +
                          "<div tabindex=\"1\">First</div>" +
                          "<a href=\"#\" tabindex=\"2\">Link</a>" +
                          "<p>No tabindex</p>" +
                          "<input type=\"text\" tabindex=\"3\"/>" +
                          "</body></html>";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html))
            {
                Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("[tabindex]");
                foreach (Aspose.Html.Dom.Node node in elements)
                {
                    Aspose.Html.Dom.Element element = node as Aspose.Html.Dom.Element;
                    if (element != null)
                    {
                        string tabindex = element.GetAttribute("tabindex");
                        string tagName = element.NodeName;
                        Console.WriteLine($"{tagName} - tabindex={tabindex}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}