// Detect and remove empty elements that contain no child nodes or text content.

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

            using (HTMLDocument document = new HTMLDocument(inputPath))
            {
                HTMLCollection allElements = document.GetElementsByTagName("*");
                var toRemove = new System.Collections.Generic.List<Element>();

                foreach (Element element in allElements)
                {
                    if (!element.HasChildNodes() && string.IsNullOrWhiteSpace(element.TextContent))
                    {
                        toRemove.Add(element);
                    }
                }

                foreach (Element element in toRemove)
                {
                    Node parent = element.ParentNode;
                    if (parent != null)
                    {
                        parent.RemoveChild(element);
                    }
                }

                document.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}