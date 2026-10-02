// Identify and list all elements with role attributes for accessibility compliance review.

using System;

namespace AsposeHtmlRoleExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><div role=\"banner\">Header</div><nav role=\"navigation\">Menu</nav><section>Content</section><button role=\"button\">Click</button></body></html>";
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
                {
                    Aspose.Html.Collections.NodeList nodes = document.QuerySelectorAll("[role]");
                    for (int i = 0; i < nodes.Length; i++)
                    {
                        Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)nodes[i];
                        string tagName = element.TagName;
                        string roleValue = element.GetAttribute("role");
                        Console.WriteLine($"Tag: {tagName}, Role: {roleValue}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}