// Extract image URLs using XPath "//img/@src" and write them to a text file.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;

class Program
{
    static void Main()
    {
        try
        {
            string htmlFilePath = "input.html";
            string outputFilePath = "image_urls.txt";

            HTMLDocument doc = new HTMLDocument(htmlFilePath);
            IXPathResult result = doc.Evaluate("//img", doc, doc.CreateNSResolver(doc), XPathResultType.Any, null);

            using (StreamWriter writer = new StreamWriter(outputFilePath, false))
            {
                Node node;
                while ((node = result.IterateNext()) != null)
                {
                    HTMLImageElement img = (HTMLImageElement)node;
                    writer.WriteLine(img.Src);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}