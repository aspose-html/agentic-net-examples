// Load an HTML document and count the number of heading elements from h1 to h3 using XPath.

using System;
using System.IO;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            string htmlContent = "<html><body>" +
                                 "<h1>Heading 1</h1>" +
                                 "<h2>Heading 2</h2>" +
                                 "<h3>Heading 3</h3>" +
                                 "<h4>Heading 4</h4>" +
                                 "</body></html>";
            File.WriteAllText(inputPath, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(inputPath);

            // Evaluate XPath to select h1, h2, h3 elements
            IXPathResult result = doc.Evaluate(
                "//h1|//h2|//h3",
                doc,
                doc.CreateNSResolver(doc),
                Aspose.Html.Dom.XPath.XPathResultType.Any,
                null);

            // Count the selected heading elements
            int headingCount = 0;
            Aspose.Html.Dom.Node node;
            while ((node = result.IterateNext()) != null)
            {
                headingCount++;
            }

            Console.WriteLine($"Number of heading elements (h1-h3): {headingCount}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}