// Construct an XPath expression "//img" to select all image nodes.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with images
            string html = @"
                <html>
                    <body>
                        <img src='image1.png' class='photo' />
                        <img src='image2.png' />
                    </body>
                </html>";

            // Load HTML content into a document (base URL is empty)
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(html, "");

            // Evaluate XPath to select all img elements
            Aspose.Html.Dom.XPath.IXPathResult result = doc.Evaluate(
                "//img",
                doc,
                doc.CreateNSResolver(doc),
                Aspose.Html.Dom.XPath.XPathResultType.Any,
                null);

            // Iterate over the selected nodes and output the src attribute
            Aspose.Html.Dom.Node node;
            while ((node = result.IterateNext()) != null)
            {
                Aspose.Html.HTMLImageElement img = (Aspose.Html.HTMLImageElement)node;
                Console.WriteLine(img.Src);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}