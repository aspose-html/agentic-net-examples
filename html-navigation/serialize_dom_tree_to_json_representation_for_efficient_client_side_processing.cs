// Serialize the DOM tree to a JSON representation for efficient client‑side processing.

using System;
using System.Text.Json.Nodes;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><body><div><p>Hello</p><span>World</span></div></body></html>";
            using Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "");

            JsonNode json = NodeToJson(document.DocumentElement);
            Console.WriteLine(json.ToJsonString());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static JsonNode NodeToJson(Aspose.Html.Dom.Node node)
    {
        var obj = new JsonObject
        {
            ["nodeName"] = node.NodeName,
            ["nodeType"] = node.NodeType.ToString()
        };

        if (!string.IsNullOrEmpty(node.TextContent))
        {
            obj["textContent"] = node.TextContent;
        }

        var childrenArray = new JsonArray();
        for (Aspose.Html.Dom.Node child = node.FirstChild; child != null; child = child.NextSibling)
        {
            childrenArray.Add(NodeToJson(child));
        }

        if (childrenArray.Count > 0)
        {
            obj["children"] = childrenArray;
        }

        return obj;
    }
}