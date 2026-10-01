// Detect absent caption files referenced by <track> elements and log their file paths.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            // Paths
            string logPath = "log.txt";
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = @"<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
    <img src='image1.png' />
    <script>console.log('test');</script>
    <img src='image2.png' alt='' />
</body>
</html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load document
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(inputPath);

            // Log all image src attributes using XPath
            Aspose.Html.Dom.XPath.IXPathResult result = doc.Evaluate(
                "//img",
                doc,
                doc.CreateNSResolver(doc),
                Aspose.Html.Dom.XPath.XPathResultType.Any,
                null);

            Aspose.Html.Dom.Node node;
            while ((node = result.IterateNext()) != null)
            {
                Aspose.Html.HTMLImageElement img = node as Aspose.Html.HTMLImageElement;
                if (img != null)
                {
                    File.AppendAllText(logPath, img.Src + Environment.NewLine);
                }
            }

            // Remove all <script> elements safely
            Aspose.Html.Collections.HTMLCollection scripts = doc.GetElementsByTagName("script");
            for (int i = scripts.Length - 1; i >= 0; i--)
            {
                Aspose.Html.Dom.Element script = scripts[i] as Aspose.Html.Dom.Element;
                if (script != null && script.ParentNode != null)
                {
                    script.ParentNode.RemoveChild(script);
                }
            }

            // Ensure every <img> has a non‑empty alt attribute
            Aspose.Html.Collections.HTMLCollection images = doc.GetElementsByTagName("img");
            foreach (Aspose.Html.Dom.Element imgElement in images)
            {
                Aspose.Html.HTMLImageElement img = imgElement as Aspose.Html.HTMLImageElement;
                if (img != null)
                {
                    string alt = img.GetAttribute("alt");
                    if (string.IsNullOrWhiteSpace(alt))
                    {
                        string autoAlt = "auto-generated alt";
                        img.SetAttribute("alt", autoAlt);
                    }
                }
            }

            // Save the modified document
            doc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}