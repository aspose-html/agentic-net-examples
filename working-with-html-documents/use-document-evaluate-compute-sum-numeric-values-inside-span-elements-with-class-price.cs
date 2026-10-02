// Use Document.Evaluate to compute the sum of numeric values inside span elements with class "price".

using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string html = "<html><body>" +
                          "<span class='price'>12.5</span>" +
                          "<div><span class='price'>7.30</span></div>" +
                          "<span class='price'>10</span>" +
                          "<span class='other'>5</span>" +
                          "</body></html>";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank"))
            {
                Aspose.Html.Dom.XPath.IXPathResult result = document.Evaluate(
                    "//span[contains(concat(' ', normalize-space(@class), ' '), ' price ')]",
                    document,
                    document.CreateNSResolver(document),
                    Aspose.Html.Dom.XPath.XPathResultType.Any,
                    null);

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
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}