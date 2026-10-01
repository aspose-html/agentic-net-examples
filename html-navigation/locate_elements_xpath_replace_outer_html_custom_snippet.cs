// Locate elements matching an XPath expression and replace their outer HTML with a custom snippet.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body><div class='target'>Old Content</div><p>Other Content</p></body></html>";
            // Create HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "");

            // XPath expression to select target elements
            string xpathExpression = "//*[contains(@class,'target')]";

            // Evaluate XPath
            Aspose.Html.Dom.XPath.IXPathResult result = document.Evaluate(
                xpathExpression,
                document,
                null,
                Aspose.Html.Dom.XPath.XPathResultType.Any,
                null);

            // Iterate over matched nodes and replace outer HTML
            Aspose.Html.Dom.Node node;
            while ((node = result.IterateNext()) != null)
            {
                Aspose.Html.HTMLElement element = node as Aspose.Html.HTMLElement;
                if (element != null)
                {
                    element.OuterHTML = "<span class='target'>New Content</span>";
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