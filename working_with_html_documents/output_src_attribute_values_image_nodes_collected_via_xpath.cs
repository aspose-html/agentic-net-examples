// Output the src attribute values of the image nodes collected via XPath.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlPath = "sample.html";
                HTMLDocument doc = new HTMLDocument(htmlPath);
                IXPathResult result = doc.Evaluate("//img", doc, doc.CreateNSResolver(doc), XPathResultType.Any, null);
                Node node;
                while ((node = result.IterateNext()) != null)
                {
                    HTMLImageElement img = (HTMLImageElement)node;
                    string src = img.Src;
                    Console.WriteLine(src);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}