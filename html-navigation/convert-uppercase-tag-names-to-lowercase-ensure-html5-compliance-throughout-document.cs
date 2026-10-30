// Convert all uppercase tag names to lowercase to ensure HTML5 compliance throughout the document.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<HTML><HEAD><TITLE>Test</TITLE></HEAD><BODY><DIV>Content</DIV></BODY></HTML>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.Collections.HTMLCollection elements = document.GetElementsByTagName("*");
            for (int i = 0; i < elements.Length; i++)
            {
                Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)elements[i];
                string tagName = element.TagName;
                string lowerTag = tagName.ToLowerInvariant();
                if (tagName != lowerTag)
                {
                    Aspose.Html.Dom.Element newElement = (Aspose.Html.Dom.Element)document.CreateElement(lowerTag);

                    // Copy attributes
                    Aspose.Html.Collections.NamedNodeMap attrs = element.Attributes;
                    for (int a = 0; a < attrs.Length; a++)
                    {
                        Aspose.Html.Dom.Attr attr = (Aspose.Html.Dom.Attr)attrs[a];
                        newElement.SetAttribute(attr.Name, attr.Value);
                    }

                    // Move child nodes
                    while (element.FirstChild != null)
                    {
                        newElement.AppendChild(element.FirstChild);
                    }

                    // Replace the old element with the new one
                    element.ParentNode.ReplaceChild(newElement, element);
                }
            }

            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine("Converted document saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}