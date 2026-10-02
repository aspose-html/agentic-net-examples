// Count the number of <img> nodes using XPath and output the total count.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string html = @"<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
    <img src='image1.png' />
    <div>
        <img src='image2.jpg' />
        <p>Text</p>
        <img src='image3.gif' />
    </div>
</body>
</html>";

            // Load HTML content using the two-argument constructor (content, baseUri)
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(html, "about:blank");

            // Evaluate XPath to select all <img> elements
            Aspose.Html.Dom.XPath.IXPathResult result = doc.Evaluate(
                "//img",
                doc,
                doc.CreateNSResolver(doc),
                Aspose.Html.Dom.XPath.XPathResultType.Any,
                null);

            Aspose.Html.Dom.Node node;
            int count = 0;

            while ((node = result.IterateNext()) != null)
            {
                Aspose.Html.HTMLImageElement img = (Aspose.Html.HTMLImageElement)node;
                // Optionally, you could use img.Src here
                count++;
            }

            Console.WriteLine($"Total <img> count: {count}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}