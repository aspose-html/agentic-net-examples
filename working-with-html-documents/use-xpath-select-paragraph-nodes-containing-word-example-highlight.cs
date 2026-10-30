// Use XPath to select paragraph nodes containing the word "example" and highlight them.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><p>This is an example paragraph.</p><p>Another line.</p><p>example again.</p></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");

            string xpath = "//p[contains(., 'example')]";
            Aspose.Html.Dom.XPath.IXPathResult result = document.Evaluate(xpath, document, null, Aspose.Html.Dom.XPath.XPathResultType.Any, null);

            Aspose.Html.Dom.Node node = result.IterateNext();
            while (node != null)
            {
                Aspose.Html.Dom.Element element = node as Aspose.Html.Dom.Element;
                if (element != null)
                {
                    string existingStyle = element.GetAttribute("style");
                    string highlight = "background-color: yellow;";
                    string newStyle = string.IsNullOrEmpty(existingStyle) ? highlight : existingStyle + " " + highlight;
                    element.SetAttribute("style", newStyle);
                }
                node = result.IterateNext();
            }

            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine("Document saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}