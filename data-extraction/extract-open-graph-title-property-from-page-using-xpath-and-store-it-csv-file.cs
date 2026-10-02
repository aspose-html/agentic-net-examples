// Extract the Open Graph title property from a page using XPath and store it in a CSV file.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML containing Open Graph title
            string htmlContent = "<html><head><meta property='og:title' content='Sample Title'></head><body></body></html>";

            // Load HTML from string using two-argument constructor
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Evaluate XPath to find the meta element with property og:title
            Aspose.Html.Dom.XPath.IXPathResult xpathResult = document.Evaluate(
                "//meta[@property='og:title']",
                document,
                null,
                Aspose.Html.Dom.XPath.XPathResultType.Any,
                null);

            // Get the first matching node
            Aspose.Html.Dom.Node node = xpathResult.IterateNext();

            // Extract the content attribute value
            string title = string.Empty;
            if (node != null)
            {
                var element = node as Aspose.Html.Dom.Element;
                if (element != null)
                {
                    title = element.GetAttribute("content");
                }
            }

            // Write the title to a CSV file
            string csvPath = "output.csv";
            using (var writer = new StreamWriter(csvPath, false))
            {
                writer.WriteLine("Title");
                writer.WriteLine($"\"{title}\"");
            }

            Console.WriteLine($"Open Graph title extracted and saved to '{csvPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}