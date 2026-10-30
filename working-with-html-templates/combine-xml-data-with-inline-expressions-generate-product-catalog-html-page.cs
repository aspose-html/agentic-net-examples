// Combine XML data with inline expressions to generate a product catalog HTML page.

using System;
using System.Text;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            // Sample XML data representing products
            string xmlContent = @"
<Products>
    <Product>
        <Name>Widget A</Name>
        <Price>19.99</Price>
        <Description>High quality widget.</Description>
    </Product>
    <Product>
        <Name>Gadget B</Name>
        <Price>29.95</Price>
        <Description>Multi‑purpose gadget.</Description>
    </Product>
    <Product>
        <Name>Device C</Name>
        <Price>99.00</Price>
        <Description>Advanced device with many features.</Description>
    </Product>
</Products>";

            // Basic HTML template for the catalog
            string htmlTemplate = @"
<html>
<head>
    <meta charset=""UTF-8"">
    <title>Product Catalog</title>
    <style>
        .product { margin-bottom: 20px; }
        .product h2 { margin: 0; }
    </style>
</head>
<body>
    <h1>Product Catalog</h1>
    <div id=""catalog""></div>
</body>
</html>";

            // Load XML and HTML documents (use two‑argument constructor with a dummy base URI)
            var xmlDoc = new Aspose.Html.HTMLDocument(xmlContent, "about:blank");
            var htmlDoc = new Aspose.Html.HTMLDocument(htmlTemplate, "about:blank");

            // XPath to select all Product nodes
            IXPathResult productNodes = xmlDoc.Evaluate("//Product", xmlDoc, xmlDoc.CreateNSResolver(xmlDoc), Aspose.Html.Dom.XPath.XPathResultType.Any, null);

            Aspose.Html.Dom.Node productNode;
            while ((productNode = productNodes.IterateNext()) != null)
            {
                // Extract Name
                IXPathResult nameResult = xmlDoc.Evaluate("string(Name)", productNode, xmlDoc.CreateNSResolver(xmlDoc), Aspose.Html.Dom.XPath.XPathResultType.String, null);
                string name = nameResult.StringValue;

                // Extract Price
                IXPathResult priceResult = xmlDoc.Evaluate("string(Price)", productNode, xmlDoc.CreateNSResolver(xmlDoc), Aspose.Html.Dom.XPath.XPathResultType.String, null);
                string price = priceResult.StringValue;

                // Extract Description
                IXPathResult descResult = xmlDoc.Evaluate("string(Description)", productNode, xmlDoc.CreateNSResolver(xmlDoc), Aspose.Html.Dom.XPath.XPathResultType.String, null);
                string description = descResult.StringValue;

                // Build product HTML fragment
                string productHtml = $"<div class=\"product\"><h2>{System.Net.WebUtility.HtmlEncode(name)}</h2><p>{System.Net.WebUtility.HtmlEncode(description)}</p><p>Price: ${System.Net.WebUtility.HtmlEncode(price)}</p></div>";

                // Create a container element and set its inner HTML
                var container = (Aspose.Html.HTMLElement)htmlDoc.CreateElement("div");
                container.InnerHTML = productHtml;

                // Append to the catalog div
                var catalogDiv = (Aspose.Html.HTMLElement)htmlDoc.GetElementById("catalog");
                catalogDiv.AppendChild(container);
            }

            // Save the generated catalog to a file
            string outputPath = "catalog.html";
            htmlDoc.Save(outputPath);
            Console.WriteLine($"Product catalog generated successfully: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}