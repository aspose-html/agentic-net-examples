// Use Document.Evaluate to compute the sum of numeric values inside span elements with class "price".

using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with price spans
            string html = @"<html><body>" +
                          @"<span class='price'>12.34</span>" +
                          @"<span class='price'>56.78</span>" +
                          @"<div class='price'>Not a number</div>" +
                          @"</body></html>";

            // Load document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("", html);

            // XPath to find price spans and sum their numeric values
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

            // Query selector example: select all div elements and print their inner HTML
            Aspose.Html.Collections.NodeList divElements = document.QuerySelectorAll("div");
            foreach (Aspose.Html.HTMLElement element in divElements)
            {
                Console.WriteLine(element.InnerHTML);
            }

            // Pixel to various unit conversions
            int widthPixels = 800;
            int heightPixels = 600;
            const double ppi = 96.0;

            double widthInches = widthPixels / ppi;
            double heightInches = heightPixels / ppi;

            double widthCentimeters = widthInches * 2.54;
            double heightCentimeters = heightInches * 2.54;

            double widthMillimeters = widthCentimeters * 10.0;
            double heightMillimeters = heightCentimeters * 10.0;

            double widthPoints = widthInches * 72.0;
            double heightPoints = heightInches * 72.0;

            double widthPicas = widthInches * 6.0;
            double heightPicas = heightInches * 6.0;

            Console.WriteLine($"Width: {widthPixels}px = {widthInches}in = {widthCentimeters}cm = {widthMillimeters}mm = {widthPoints}pt = {widthPicas}pc");
            Console.WriteLine($"Height: {heightPixels}px = {heightInches}in = {heightCentimeters}cm = {heightMillimeters}mm = {heightPoints}pt = {heightPicas}pc");

            // Create a new empty document and add a style element
            Aspose.Html.HTMLDocument emptyDoc = new Aspose.Html.HTMLDocument();
            Aspose.Html.Dom.Element styleElement = emptyDoc.CreateElement("style");
            Aspose.Html.HTMLElement styleHtmlElement = (Aspose.Html.HTMLElement)styleElement;
            styleHtmlElement.TextContent = "body { background-color: #f0f0f0; }";
            emptyDoc.Body.AppendChild(styleHtmlElement);
            Console.WriteLine("Added style element to empty document.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}