// Use XPath to select all table cells containing numeric values and calculate their sum programmatically.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><table><tr><td>10</td><td>abc</td></tr><tr><td>20.5</td><td>30</td></tr></table></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                Aspose.Html.Dom.XPath.IXPathResult result = document.Evaluate("//td", document, document.CreateNSResolver(document), Aspose.Html.Dom.XPath.XPathResultType.Any, null);
                double sum = 0;
                Aspose.Html.Dom.Node node;
                while ((node = result.IterateNext()) != null)
                {
                    string text = node.TextContent;
                    if (double.TryParse(text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double value))
                    {
                        sum += value;
                    }
                }
                System.Console.WriteLine(sum.ToString(System.Globalization.CultureInfo.InvariantCulture));
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}