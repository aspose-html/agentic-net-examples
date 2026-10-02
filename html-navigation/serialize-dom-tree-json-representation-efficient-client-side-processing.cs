// Serialize the DOM tree to a JSON representation for efficient client‑side processing.

using System;
using System.Text.Json.Nodes;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><div>Hello <span>World</span></div></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank"))
            {
                Aspose.Html.Dom.XPath.IXPathResult result = document.Evaluate("//node()", document, null, Aspose.Html.Dom.XPath.XPathResultType.Any, null);
                JsonArray nodesArray = new JsonArray();

                for (Aspose.Html.Dom.Node node; (node = result.IterateNext()) != null;)
                {
                    JsonObject obj = new JsonObject
                    {
                        ["nodeName"] = node.NodeName,
                        ["textContent"] = node.TextContent
                    };
                    nodesArray.Add(obj);
                }

                string json = nodesArray.ToJsonString();
                Console.WriteLine(json);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}