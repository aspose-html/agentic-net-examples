// Use Document.Evaluate to compute the sum of numeric values inside span elements with class "price".

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
            string htmlContent = "<html><body>" +
                                 "<span class=\"price\">10.5</span>" +
                                 "<span class=\"price\">20</span>" +
                                 "<span class=\"price\">5.25</span>" +
                                 "</body></html>";

            using (HTMLDocument document = new HTMLDocument(htmlContent, "about:blank"))
            {
                IXPathResult result = document.Evaluate(
                    "//span[contains(concat(' ', normalize-space(@class), ' '), ' price ')]",
                    document,
                    document.CreateNSResolver(document),
                    XPathResultType.Any,
                    null);

                double sum = 0;
                Node node;
                while ((node = result.IterateNext()) != null)
                {
                    if (double.TryParse(node.TextContent, NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
                    {
                        sum += value;
                    }
                }

                Console.WriteLine(sum.ToString(CultureInfo.InvariantCulture));
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}