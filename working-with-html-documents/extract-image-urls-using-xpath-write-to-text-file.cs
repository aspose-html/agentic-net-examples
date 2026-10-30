// Extract image URLs using XPath "//img/@src" and write them to a text file.

using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<html><body>" +
                                    "<img src=\"https://example.com/image1.png\" />" +
                                    "<img src=\"/images/image2.jpg\" />" +
                                    "</body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            string outputPath = "image_urls.txt";

            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(inputPath);
            Aspose.Html.Dom.XPath.IXPathResult result = doc.Evaluate("//img", doc, doc.CreateNSResolver(doc), Aspose.Html.Dom.XPath.XPathResultType.Any, null);
            List<string> urls = new List<string>();
            Aspose.Html.Dom.Node node;
            while ((node = result.IterateNext()) != null)
            {
                Aspose.Html.HTMLImageElement img = (Aspose.Html.HTMLImageElement)node;
                if (!string.IsNullOrEmpty(img.Src))
                {
                    urls.Add(img.Src);
                }
            }

            File.WriteAllLines(outputPath, urls);
            Console.WriteLine($"Extracted {urls.Count} image URLs to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}