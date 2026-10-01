// Trim leading and trailing whitespace from every text node to ensure consistent spacing.

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
            string htmlContent = "<html><body><p>   Hello   world   </p><div>   Sample   <span>  Text </span>   </div></body></html>";
            using Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "");

            Aspose.Html.Dom.XPath.IXPathResult result = document.Evaluate("//text()", document, null, Aspose.Html.Dom.XPath.XPathResultType.Any, null);
            Aspose.Html.Dom.Node node;
            while ((node = result.IterateNext()) != null)
            {
                string trimmed = node.TextContent.Trim();
                node.TextContent = trimmed;
            }

            string outputHtml = document.DocumentElement.OuterHTML;
            Console.WriteLine(outputHtml);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}