// Support extraction of favicon.ico files by handling link elements with rel='shortcut icon'.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Load a sample web page
            string url = "https://example.com";
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(url);

            // Find <link rel="shortcut icon"> elements
            Aspose.Html.Dom.XPath.IXPathResult result = doc.Evaluate(
                "//link[@rel='shortcut icon']",
                doc,
                doc.CreateNSResolver(doc),
                Aspose.Html.Dom.XPath.XPathResultType.Any,
                null);

            Aspose.Html.Dom.Node node;
            while ((node = result.IterateNext()) != null)
            {
                Aspose.Html.HTMLLinkElement link = (Aspose.Html.HTMLLinkElement)node;
                Console.WriteLine(link.Href);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}