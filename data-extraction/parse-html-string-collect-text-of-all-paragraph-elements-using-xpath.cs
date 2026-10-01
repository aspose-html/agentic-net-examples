// Parse an HTML string and collect the text of all paragraph elements using XPath.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><p>First paragraph.</p><div><p>Second paragraph.</p></div></body></html>";
            var document = new Aspose.Html.HTMLDocument(html, "about:blank");
            var result = document.Evaluate("//p", document, null, Aspose.Html.Dom.XPath.XPathResultType.Any, null);
            Aspose.Html.Dom.Node node = result.IterateNext();
            while (node != null)
            {
                var element = node as Aspose.Html.HTMLElement;
                if (element != null)
                {
                    Console.WriteLine(element.InnerHTML);
                }
                node = result.IterateNext();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}