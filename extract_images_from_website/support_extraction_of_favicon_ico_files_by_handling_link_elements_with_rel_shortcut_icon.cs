// Support extraction of favicon.ico files by handling link elements with rel='shortcut icon'.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;

class Program
{
    static void Main()
    {
        try
        {
            // Load the HTML document from a file
            var document = new HTMLDocument("input.html");

            // XPath to select <link> elements with rel='shortcut icon'
            var xpath = "//link[@rel='shortcut icon']";

            // Evaluate the XPath expression
            IXPathResult result = document.Evaluate(
                xpath,
                document,
                document.CreateNSResolver(document),
                XPathResultType.Any,
                null);

            // Iterate over the matching nodes and output the href attribute
            Node node;
            while ((node = result.IterateNext()) != null)
            {
                var link = (HTMLLinkElement)node;
                Console.WriteLine(link.Href);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}