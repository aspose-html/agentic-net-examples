// Remove all empty paragraph tags that contain only whitespace characters in the document.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content with empty paragraphs
            string htmlContent = "<html><body><p>   </p><p>Text</p><p>\n\t</p></body></html>";

            // Load document from inline HTML
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get all paragraph elements
            Aspose.Html.Collections.HTMLCollection paragraphs = document.GetElementsByTagName("p");

            // Iterate backwards and remove empty paragraphs
            for (int i = paragraphs.Length - 1; i >= 0; i--)
            {
                Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)paragraphs[i];
                if (element.TextContent.Trim().Length == 0 && element.ParentNode != null)
                {
                    element.ParentNode.RemoveChild(element);
                }
            }

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}