// Extract image URLs using XPath "//img/@src" and write them to a text file.

using System;
using System.Collections.Generic;
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
            string htmlContent = "<html><body><img src='image1.jpg'/><img src='http://example.com/image2.png'/></body></html>";
            HTMLDocument doc = new HTMLDocument(htmlContent, "about:blank");
            IXPathResult result = doc.Evaluate("//img", doc, doc.CreateNSResolver(doc), XPathResultType.Any, null);
            List<string> imageUrls = new List<string>();
            Node node;
            while ((node = result.IterateNext()) != null)
            {
                HTMLImageElement img = (HTMLImageElement)node;
                string src = img.Src;
                if (!string.IsNullOrEmpty(src))
                {
                    imageUrls.Add(src);
                }
            }
            string outputFile = "image_urls.txt";
            File.WriteAllLines(outputFile, imageUrls);
            Console.WriteLine($"Extracted {imageUrls.Count} image URLs to {outputFile}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}