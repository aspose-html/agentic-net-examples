// Identify and list all elements with role attributes for accessibility compliance review.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head><title>Test</title></head><body><div role='main'>Main content</div><nav role='navigation'>Nav</nav><section>No role</section></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank"))
            {
                Aspose.Html.Collections.NodeList allElements = document.QuerySelectorAll("*");
                for (int i = 0; i < allElements.Length; i++)
                {
                    Aspose.Html.Dom.Node node = allElements[i];
                    if (node.NodeType == Aspose.Html.Dom.Node.ELEMENT_NODE)
                    {
                        Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)node;
                        string role = element.GetAttribute("role");
                        if (!string.IsNullOrEmpty(role))
                        {
                            Console.WriteLine($"Tag: {element.TagName}, Role: {role}");
                        }
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