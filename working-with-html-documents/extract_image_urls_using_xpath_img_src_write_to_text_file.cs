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
            // Define input and output paths
            string inputPath = "sample.html";
            string outputPath = "image_urls.txt";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = @"<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
    <img src=""https://example.com/image1.png"" />
    <img src=""https://example.com/image2.jpg"" />
</body>
</html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document
            HTMLDocument doc = new HTMLDocument(inputPath);

            // Evaluate XPath to select all img src attributes
            IXPathResult result = doc.Evaluate(
                "//img/@src",
                doc,
                doc.CreateNSResolver(doc),
                XPathResultType.Any,
                null);

            // Collect the src values
            List<string> srcList = new List<string>();
            Node node;
            while ((node = result.IterateNext()) != null)
            {
                // NodeValue contains the attribute value
                string src = node.NodeValue;
                if (!string.IsNullOrEmpty(src))
                {
                    srcList.Add(src);
                }
            }

            // Write the URLs to a text file
            File.WriteAllLines(outputPath, srcList);

            Console.WriteLine($"Extracted {srcList.Count} image URLs to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}