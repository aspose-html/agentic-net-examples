// Load an HTML document and count the number of heading elements from h1 to h3 using XPath.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Title</h1><h2>Subtitle</h2><h3>Section</h3><h4>Not counted</h4></body></html>";
            string inputPath = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(inputPath, htmlContent);

            var doc = new Aspose.Html.HTMLDocument(inputPath);

            string xpath = "//h1 | //h2 | //h3";
            Aspose.Html.Dom.XPath.IXPathResult result = doc.Evaluate(xpath, doc, doc.CreateNSResolver(doc), Aspose.Html.Dom.XPath.XPathResultType.Any, null);
            int count = 0;
            Aspose.Html.Dom.Node node;
            while ((node = result.IterateNext()) != null)
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