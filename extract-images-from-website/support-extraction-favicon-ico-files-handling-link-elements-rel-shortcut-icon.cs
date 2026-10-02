// Support extraction of favicon.ico files by handling link elements with rel='shortcut icon'.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head><link rel='shortcut icon' href='favicon.ico'></head><body></body></html>";
            var doc = new Aspose.Html.HTMLDocument(html, "about:blank");
            Aspose.Html.Dom.XPath.IXPathResult result = doc.Evaluate("//link[@rel='shortcut icon']", doc, doc.CreateNSResolver(doc), Aspose.Html.Dom.XPath.XPathResultType.Any, null);
            Aspose.Html.Dom.Node node;
            while ((node = result.IterateNext()) != null)
            {
                var link = node as Aspose.Html.HTMLLinkElement;
                if (link != null)
                {
                    Console.WriteLine("Favicon href: " + link.Href);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}