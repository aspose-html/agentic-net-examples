// Merge consecutive list items into a single paragraph to simplify list presentation.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            ProcessLists(document, "ul");
            ProcessLists(document, "ol");

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void ProcessLists(HTMLDocument document, string tagName)
    {
        HTMLCollection lists = document.GetElementsByTagName(tagName);
        for (int i = lists.Length - 1; i >= 0; i--)
        {
            HTMLElement list = lists[i] as HTMLElement;
            if (list == null) continue;

            string combinedText = "";
            for (Node child = list.FirstChild; child != null; child = child.NextSibling)
            {
                if (child.NodeName.Equals("li", StringComparison.OrdinalIgnoreCase))
                {
                    combinedText += child.TextContent.Trim() + " ";
                }
            }
            combinedText = combinedText.Trim();

            HTMLParagraphElement paragraph = (HTMLParagraphElement)document.CreateElement("p");
            Text textNode = document.CreateTextNode(combinedText);
            paragraph.AppendChild(textNode);

            Node parent = list.ParentNode;
            parent.InsertBefore(paragraph, list.NextSibling);
            parent.RemoveChild(list);
        }
    }
}