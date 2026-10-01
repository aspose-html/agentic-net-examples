// Evaluate the XPath expression with Document.Evaluate to obtain the image node collection.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML containing images
            string htmlContent = "<html><body>" +
                                 "<img src='image1.png' alt='First'/>" +
                                 "<img src='image2.jpg' alt='Second'/>" +
                                 "</body></html>";

            // Load the HTML into an Aspose.Html.HTMLDocument
            var document = new Aspose.Html.HTMLDocument(htmlContent);

            // Evaluate XPath to select all <img> elements
            var xpathResult = document.Evaluate(
                "//img",
                document,
                document.CreateNSResolver(document),
                Aspose.Html.Dom.XPath.XPathResultType.Any,
                null);

            // Iterate over the selected nodes and output the Src attribute
            Aspose.Html.Dom.Node node;
            while ((node = xpathResult.IterateNext()) != null)
            {
                var imageElement = (Aspose.Html.HTMLImageElement)node;
                Console.WriteLine(imageElement.Src);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}