// Combine XML data with inline expressions to generate a product catalog HTML page.

using System;

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // XML content representing the product catalog
                string xmlContent = @"<Catalog><Product><Name>Phone</Name><Price>299</Price></Product><Product><Name>Laptop</Name><Price>999</Price></Product></Catalog>";

                // Load XML into an HTMLDocument (treated as XML)
                var xmlDoc = new Aspose.Html.HTMLDocument(xmlContent, "about:blank");

                // Create an HTML document that will hold the generated catalog
                string htmlTemplate = "<!DOCTYPE html><html><head><title>Product Catalog</title></head><body></body></html>";
                var htmlDoc = new Aspose.Html.HTMLDocument(htmlTemplate, "about:blank");

                // Select all Product nodes from the XML
                Aspose.Html.Dom.XPath.IXPathResult productResult = xmlDoc.Evaluate("//Product", xmlDoc, xmlDoc.CreateNSResolver(xmlDoc), Aspose.Html.Dom.XPath.XPathResultType.Any, null);
                Aspose.Html.Dom.Node productNode;
                while ((productNode = productResult.IterateNext()) != null)
                {
                    // Extract product name
                    Aspose.Html.Dom.XPath.IXPathResult nameResult = xmlDoc.Evaluate("string(Name)", productNode, xmlDoc.CreateNSResolver(xmlDoc), Aspose.Html.Dom.XPath.XPathResultType.String, null);
                    string productName = nameResult.StringValue;

                    // Extract product price
                    Aspose.Html.Dom.XPath.IXPathResult priceResult = xmlDoc.Evaluate("string(Price)", productNode, xmlDoc.CreateNSResolver(xmlDoc), Aspose.Html.Dom.XPath.XPathResultType.String, null);
                    string productPrice = priceResult.StringValue;

                    // Build HTML elements for the product
                    var productDiv = (Aspose.Html.HTMLElement)htmlDoc.CreateElement("div");
                    productDiv.SetAttribute("class", "product");

                    var nameHeader = (Aspose.Html.HTMLElement)htmlDoc.CreateElement("h2");
                    nameHeader.TextContent = productName;

                    var priceParagraph = (Aspose.Html.HTMLElement)htmlDoc.CreateElement("p");
                    priceParagraph.TextContent = $"Price: ${productPrice}";

                    productDiv.AppendChild(nameHeader);
                    productDiv.AppendChild(priceParagraph);

                    // Append the product block to the body of the HTML document
                    htmlDoc.Body.AppendChild(productDiv);
                }

                // Save the generated catalog to a file
                htmlDoc.Save("catalog.html");
                Console.WriteLine("Product catalog generated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}