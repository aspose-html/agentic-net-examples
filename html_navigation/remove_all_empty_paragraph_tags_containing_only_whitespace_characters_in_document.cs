// Remove all empty paragraph tags that contain only whitespace characters in the document.

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

            HTMLDocument document = new HTMLDocument(inputPath);
            HTMLCollection paragraphs = document.GetElementsByTagName("p");

            for (int i = paragraphs.Length - 1; i >= 0; i--)
            {
                Element p = (Element)paragraphs[i];
                if (string.IsNullOrWhiteSpace(p.TextContent))
                {
                    Node parent = p.ParentNode;
                    if (parent != null)
                    {
                        parent.RemoveChild(p);
                    }
                }
            }

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}