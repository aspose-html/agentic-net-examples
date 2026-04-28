// Serialize the DOM tree to a JSON representation for efficient client‑side processing.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using System.Text;

namespace DomToJsonExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string html = "<!DOCTYPE html><html><body><div><p>Hello</p><span>World</span></div></body></html>";
                string baseUri = "http://example.com";

                using (HTMLDocument document = new HTMLDocument(html, baseUri))
                {
                    var root = document.DocumentElement;
                    string json = NodeToJson(root);
                    Console.WriteLine(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static string NodeToJson(Node node)
        {
            var sb = new StringBuilder();
            sb.Append("{");
            sb.AppendFormat("\"nodeName\":\"{0}\"", node.NodeName);
            if (!string.IsNullOrWhiteSpace(node.TextContent))
            {
                sb.AppendFormat(",\"text\":\"{0}\"", node.TextContent.Replace("\"", "\\\""));
            }
            var element = node as Element;
            if (element != null && element.HasChildNodes())
            {
                sb.Append(",\"children\":[");
                bool first = true;
                foreach (Node child in element.ChildNodes)
                {
                    if (!first) sb.Append(",");
                    sb.Append(NodeToJson(child));
                    first = false;
                }
                sb.Append("]");
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
}