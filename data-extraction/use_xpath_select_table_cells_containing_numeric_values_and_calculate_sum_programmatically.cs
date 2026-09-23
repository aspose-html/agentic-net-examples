// Use XPath to select all table cells containing numeric values and calculate their sum programmatically.

using System;
using System.Globalization;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><table><tr><td>10</td><td>abc</td></tr><tr><td>20.5</td><td>30</td></tr></table></body></html>";

            using Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "");

            Aspose.Html.Dom.XPath.IXPathResult result = document.Evaluate("//td", document, document.CreateNSResolver(document), Aspose.Html.Dom.XPath.XPathResultType.Any, null);

            double sum = 0;
            Aspose.Html.Dom.Node node;
            while ((node = result.IterateNext()) != null)
            {
                if (double.TryParse(node.TextContent, NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
                {
                    sum += value;
                }
            }

            Console.WriteLine(sum.ToString(CultureInfo.InvariantCulture));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}