// Extract the Open Graph title property from a page using XPath and store it in a CSV file.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Load the HTML document from a URL (replace with the desired page)
            var document = new Aspose.Html.HTMLDocument("https://example.com");

            // Evaluate XPath to get the Open Graph title content attribute
            var result = document.Evaluate(
                "//meta[@property='og:title']/@content",
                document,
                document.CreateNSResolver(document),
                Aspose.Html.Dom.XPath.XPathResultType.Any,
                null);

            var node = result.IterateNext();
            string ogTitle = node != null ? node.TextContent : string.Empty;

            // Prepare CSV content
            string csvPath = "og_title.csv";
            using (var writer = new StreamWriter(csvPath, false))
            {
                writer.WriteLine("Title");
                writer.WriteLine($"\"{ogTitle.Replace("\"", "\"\"")}\"");
            }

            Console.WriteLine($"Open Graph title extracted and saved to '{csvPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}