// Reorder list items alphabetically based on their text values and update the syntax tree.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Prepare input HTML content
            string inputHtml = "<html><body><ul><li>Banana</li><li>Apple</li><li>Cherry</li></ul></body></html>";

            // Load document using two‑argument constructor (content, baseUri)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputHtml, "about:blank");

            // Find the first <ul> element
            Aspose.Html.HTMLElement ul = (Aspose.Html.HTMLElement)document.QuerySelector("ul");
            if (ul == null)
                throw new InvalidOperationException("No <ul> element found in the document.");

            // Collect text of all <li> children
            List<string> items = new List<string>();
            Aspose.Html.Collections.NodeList liNodes = ul.QuerySelectorAll("li");
            for (int i = 0; i < liNodes.Length; i++)
            {
                Aspose.Html.HTMLElement li = (Aspose.Html.HTMLElement)liNodes[i];
                items.Add(li.TextContent.Trim());
            }

            // Sort items alphabetically
            items.Sort(StringComparer.Ordinal);

            // Remove existing <li> children
            Aspose.Html.Dom.Node child = ul.FirstChild;
            while (child != null)
            {
                Aspose.Html.Dom.Node next = child.NextSibling;
                if (child.NodeName.Equals("li", StringComparison.OrdinalIgnoreCase))
                {
                    ul.RemoveChild(child);
                }
                child = next;
            }

            // Append sorted <li> elements
            foreach (string text in items)
            {
                Aspose.Html.HTMLElement li = (Aspose.Html.HTMLElement)document.CreateElement("li");
                Aspose.Html.Dom.Text textNode = document.CreateTextNode(text);
                li.AppendChild(textNode);
                ul.AppendChild(li);
            }

            // Prepare output folder and file
            string outputFolder = "Output";
            if (!System.IO.Directory.Exists(outputFolder))
                System.IO.Directory.CreateDirectory(outputFolder);
            string outputPath = System.IO.Path.Combine(outputFolder, "sorted.html");

            // Save the modified document
            document.Save(outputPath);

            Console.WriteLine("Sorted HTML saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}