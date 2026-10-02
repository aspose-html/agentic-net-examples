// Use HtmlDocument.QuerySelectorAll with CSS selector "img[data-important='true']" to target specific images.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><body>" +
                                 "<img src='a.jpg' data-important='true'/>" +
                                 "<img src='b.jpg'/>" +
                                 "<p>Sample paragraph.</p>" +
                                 "</body></html>";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                Aspose.Html.Collections.NodeList selectedNodes = document.QuerySelectorAll("img[data-important='true']");

                foreach (Aspose.Html.Dom.Node node in selectedNodes)
                {
                    Aspose.Html.Dom.Element element = node as Aspose.Html.Dom.Element;
                    if (element != null && element.ParentNode != null)
                    {
                        element.ParentNode.RemoveChild(element);
                    }
                }

                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine("Modified document saved to: " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}