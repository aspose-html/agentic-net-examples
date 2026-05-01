// Use inline expressions to calculate and display total price from JSON line item values.

using System;
using System.IO;
using System.Globalization;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent;
            if (args.Length > 0 && File.Exists(args[0]))
            {
                htmlContent = File.ReadAllText(args[0]);
            }
            else
            {
                htmlContent = @"
<!DOCTYPE html>
<html>
<head><title>Invoice</title></head>
<body>
    <div class='line-item'>
        <span class='price'>19.99</span>
    </div>
    <div class='line-item'>
        <span class='price'>5.50</span>
    </div>
    <div class='line-item'>
        <span class='price'>12.30</span>
    </div>
</body>
</html>";
            }

            using (HTMLDocument document = new HTMLDocument(htmlContent, ""))
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
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}