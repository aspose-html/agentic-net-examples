// Remove all <script> tags from the document using an XPath expression.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample input file
            string inputPath = "input.html";
            if (!File.Exists(inputPath))
            {
                string sampleHtml = @"<!DOCTYPE html>
<html>
<head>
    <title>Sample</title>
    <script src=""script1.js""></script>
    <script>
        console.log('inline script');
    </script>
</head>
<body>
    <h1>Hello World</h1>
    <script src=""script2.js""></script>
</body>
</html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            string outputPath = "output.html";

            // ✔ Load document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // ✔ Get all script elements
            var scripts = document.GetElementsByTagName("script");

            // ✔ Iterate safely and remove
            for (int i = scripts.Length - 1; i >= 0; i--)
            {
                var script = scripts[i];
                if (script.ParentNode != null)
                {
                    script.ParentNode.RemoveChild(script);
                }
            }

            // ✔ Save document
            document.Save(outputPath);
            Console.WriteLine($"Document saved without scripts to '{outputPath}'.");

            // Load the original document again to list script src attributes
            Aspose.Html.HTMLDocument docForListing = new Aspose.Html.HTMLDocument(inputPath);
            Aspose.Html.Collections.HTMLCollection scriptElements = docForListing.GetElementsByTagName("script");

            for (int i = 0; i < scriptElements.Length; i++)
            {
                Aspose.Html.Dom.Element scriptElement = (Aspose.Html.Dom.Element)scriptElements[i];
                string src = scriptElement.GetAttribute("src");
                if (!string.IsNullOrEmpty(src))
                {
                    Console.WriteLine($"Script src: {src}");
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}