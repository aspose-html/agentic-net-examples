// Load an HTML document, normalize whitespace in text nodes, and save the cleaned markup.

using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><p>   This   is   a   test.   </p><div>Another    line.</div></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.Collections.HTMLCollection allElements = document.GetElementsByTagName("*");
            for (int i = 0; i < allElements.Length; i++)
            {
                Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)allElements[i];
                Aspose.Html.Collections.NodeList childNodes = element.ChildNodes;
                for (int j = 0; j < childNodes.Length; j++)
                {
                    Aspose.Html.Dom.Node node = childNodes[j];
                    if (node.NodeType == Aspose.Html.Dom.Node.TEXT_NODE)
                    {
                        Aspose.Html.Dom.Text textNode = (Aspose.Html.Dom.Text)node;
                        string normalized = Regex.Replace(textNode.Data, @"\s+", " ").Trim();
                        textNode.Data = normalized;
                    }
                }
            }

            string outputPath = "cleaned.html";
            document.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}