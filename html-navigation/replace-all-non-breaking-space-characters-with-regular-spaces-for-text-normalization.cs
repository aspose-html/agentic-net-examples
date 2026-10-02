// Replace all occurrences of non‑breaking space characters with regular spaces for text normalization.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML containing non‑breaking spaces (U+00A0)
            string htmlContent = "<html><body><p>Hello\u00A0World! Non\u00A0breaking\u00A0space.</p></body></html>";
            // Load HTML from string with a dummy base URI
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            // XPath to select all text nodes
            Aspose.Html.Dom.XPath.IXPathResult result = document.Evaluate(
                "//text()",
                document,
                document.CreateNSResolver(document),
                Aspose.Html.Dom.XPath.XPathResultType.Any,
                null);
            Aspose.Html.Dom.Node node;
            while ((node = result.IterateNext()) != null)
            {
                Aspose.Html.Dom.Text textNode = node as Aspose.Html.Dom.Text;
                if (textNode != null && textNode.Data != null)
                {
                    textNode.Data = textNode.Data.Replace('\u00A0', ' ');
                }
            }
            // Save the normalized HTML to a file
            string outputPath = "normalized.html";
            document.Save(outputPath);
            Console.WriteLine("Normalization completed. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}