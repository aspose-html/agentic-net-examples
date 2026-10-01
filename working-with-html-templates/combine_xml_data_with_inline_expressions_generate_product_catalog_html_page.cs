// Combine XML data with inline expressions to generate a product catalog HTML page.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Create a minimal HTML file with sample data
            string htmlContent = @"
<html>
<body>
<table>
<tr><td>Header</td></tr>
</table>
<Dealer>
    <Name>Dealer One</Name>
    <Car id='C1'>
        <Model>2006</Model>
        <Price>20000</Price>
    </Car>
    <Car id='C2'>
        <Model>2004</Model>
        <Price>15000</Price>
    </Car>
</Dealer>
<Dealer>
    <Name>Dealer Two</Name>
    <Car id='C3'>
        <Model>2008</Model>
        <Price>24000</Price>
    </Car>
</Dealer>
</body>
</html>";
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            File.WriteAllText(inputPath, htmlContent, Encoding.UTF8);

            // Load the HTML document
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(inputPath);

            // XPath to select dealers that have at least one car with Model > 2005 and Price < 25000
            string dealersXPath = "//Dealer[descendant::Car[descendant::Model > 2005 and descendant::Price < 25000]]";

            Aspose.Html.Dom.XPath.IXPathResult dealers = doc.Evaluate(
                dealersXPath,
                doc,
                doc.CreateNSResolver(doc),
                Aspose.Html.Dom.XPath.XPathResultType.Any,
                null);

            Aspose.Html.Dom.Node dealer;
            while ((dealer = dealers.IterateNext()) != null)
            {
                // Print dealer raw text
                Console.WriteLine("Dealer block:");
                Console.WriteLine(dealer.TextContent.Trim());

                // Get dealer name
                Aspose.Html.Dom.XPath.IXPathResult dealerInfo = doc.Evaluate(
                    "string(./Name)",
                    dealer,
                    doc.CreateNSResolver(doc),
                    Aspose.Html.Dom.XPath.XPathResultType.String,
                    null);
                string dealerName = dealerInfo.StringValue;
                Console.WriteLine($"Dealer Name: {dealerName}");

                // Get car IDs for this dealer
                Aspose.Html.Dom.XPath.IXPathResult carIds = doc.Evaluate(
                    ".//Car/@id",
                    dealer,
                    doc.CreateNSResolver(doc),
                    Aspose.Html.Dom.XPath.XPathResultType.Any,
                    null);

                Aspose.Html.Dom.Node carIdNode;
                while ((carIdNode = carIds.IterateNext()) != null)
                {
                    string carIdValue = carIdNode.TextContent;
                    Console.WriteLine($"  Car ID: {carIdValue}");
                }

                Console.WriteLine();
            }

            // Clean up the temporary file
            if (File.Exists(inputPath))
            {
                File.Delete(inputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}