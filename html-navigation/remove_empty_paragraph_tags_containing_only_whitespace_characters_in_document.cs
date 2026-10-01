// Remove all empty paragraph tags that contain only whitespace characters in the document.

using System;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content with empty paragraphs
            string htmlContent = "<html><body><p>   </p><p>Hello World</p><p>\n\t</p></body></html>";

            // Load document from string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "");

            // Get all paragraph elements
            Aspose.Html.Collections.HTMLCollection paragraphs = document.GetElementsByTagName("p");

            // Iterate backwards and remove empty paragraphs
            for (int i = paragraphs.Length - 1; i >= 0; i--)
            {
                Aspose.Html.Dom.Element p = (Aspose.Html.Dom.Element)paragraphs[i];
                if (String.IsNullOrWhiteSpace(p.TextContent))
                {
                    if (p.ParentNode != null)
                    {
                        p.ParentNode.RemoveChild(p);
                    }
                }
            }

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine("Document saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}