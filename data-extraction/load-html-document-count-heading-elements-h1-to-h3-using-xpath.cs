// Load an HTML document and count the number of heading elements from h1 to h3 using XPath.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Create a sample HTML file
            string htmlPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            string htmlContent = "<!DOCTYPE html><html><body><h1>Title</h1><h2>Subtitle</h2><h3>Section</h3><h4>Ignore</h4></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            var doc = new Aspose.Html.HTMLDocument(htmlPath);

            // Evaluate XPath to select h1, h2, h3 elements
            Aspose.Html.Dom.XPath.IXPathResult result = doc.Evaluate(
                "//h1|//h2|//h3",
                doc,
                doc.CreateNSResolver(doc),
                Aspose.Html.Dom.XPath.XPathResultType.Any,
                null);

            int count = 0;
            Aspose.Html.Dom.Node node;
            while ((node = result.IterateNext() as Aspose.Html.Dom.Node) != null)
            {
                count++;
            }

            Console.WriteLine($"Number of heading elements (h1-h3): {count}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}