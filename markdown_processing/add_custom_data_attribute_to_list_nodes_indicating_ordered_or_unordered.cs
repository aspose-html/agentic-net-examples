// Add a custom data attribute to list nodes indicating whether they are ordered or unordered.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><body><ol><li>Item 1</li></ol><ul><li>Item A</li></ul></body></html>";
            var document = new Aspose.Html.HTMLDocument(html);
            var listNodes = document.QuerySelectorAll("ol, ul");
            for (int i = 0; i < listNodes.Length; i++)
            {
                var element = listNodes[i] as Aspose.Html.HTMLElement;
                if (element != null)
                {
                    string listType = element.TagName.Equals("OL", StringComparison.OrdinalIgnoreCase) ? "ordered" : "unordered";
                    element.SetAttribute("data-list-type", listType);
                }
            }
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}