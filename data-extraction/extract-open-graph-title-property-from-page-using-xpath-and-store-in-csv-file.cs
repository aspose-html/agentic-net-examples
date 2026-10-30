// Extract the Open Graph title property from a page using XPath and store it in a CSV file.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;

class Program
{
    static void Main()
    {
        try
        {
            // URL of the page to process
            string url = "https://example.com";

            // Load the HTML document from the URL
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(url);

            // XPath to select the meta tag with property og:title
            string xpath = "//meta[@property='og:title']";

            // Evaluate the XPath expression
            Aspose.Html.Dom.XPath.IXPathResult result = doc.Evaluate(
                xpath,
                doc,
                doc.CreateNSResolver(doc),
                Aspose.Html.Dom.XPath.XPathResultType.Any,
                null);

            // Get the first matching node
            Aspose.Html.Dom.Node node = result.IterateNext();

            // Extract the content attribute value
            string ogTitle = string.Empty;
            if (node != null)
            {
                Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)node;
                ogTitle = element.GetAttribute("content");
            }

            // Prepare CSV content
            string csv = "Title" + Environment.NewLine + $"\"{ogTitle}\"";

            // Write CSV to file
            string outputPath = "og_title.csv";
            File.WriteAllText(outputPath, csv);

            Console.WriteLine($"Open Graph title extracted and saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}