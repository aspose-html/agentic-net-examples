// Serialize the DOM tree to a JSON representation for efficient client‑side processing.

using System;
using System.Text.Json.Nodes;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><div>Hello <span>World</span></div><p>Paragraph</p></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                Node root = document.Body;
                JsonObject json = ConvertNode(root);
                string jsonString = json.ToJsonString();
                Console.WriteLine(jsonString);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static JsonObject ConvertNode(Node node)
    {
        JsonObject obj = new JsonObject();
        obj["nodeName"] = node.NodeName;
        obj["textContent"] = node.TextContent ?? "";

        JsonArray childrenArray = new JsonArray();
        Aspose.Html.Collections.NodeList childNodes = node.ChildNodes;
        for (int i = 0; i < childNodes.Length; i++)
        {
            Node child = childNodes[i];
            childrenArray.Add(ConvertNode(child));
        }
        obj["children"] = childrenArray;
        return obj;
    }
}