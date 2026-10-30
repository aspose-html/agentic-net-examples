// Locate elements matching an XPath expression and replace their outer HTML with a custom snippet.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body><div class='target'>Old Content</div><p>Other Content</p></body></html>";
            // Load HTML document from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // XPath expression to locate target elements
            string xpath = "//div[@class='target']";

            // Evaluate XPath
            Aspose.Html.Dom.XPath.IXPathResult result = document.Evaluate(
                xpath,
                document,
                null,
                Aspose.Html.Dom.XPath.XPathResultType.Any,
                null);

            // Replace outer HTML of each matched element
            Aspose.Html.Dom.Node node = result.IterateNext();
            while (node != null)
            {
                if (node is Aspose.Html.HTMLElement element)
                {
                    element.OuterHTML = "<section>New Content</section>";
                }
                node = result.IterateNext();
            }

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine("Processing completed. Output saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}