// Remove all noscript elements to simplify the DOM for environments without JavaScript.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample input file
            string inputPath = "input.html";
            string outputPath = "output.html";

            if (!File.Exists(inputPath))
            {
                string sampleHtml = @"
<!DOCTYPE html>
<html>
<head>
    <title>Sample</title>
    <script src='script.js'>console.log('test');</script>
</head>
<body>
    <!-- This is a comment -->
    <h1>Hello World</h1>
    <img src='image.png' />
    <script>alert('inline');</script>
</body>
</html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                // Get all script elements
                Aspose.Html.Collections.HTMLCollection scripts = document.GetElementsByTagName("script");

                // Iterate safely and remove
                for (int i = scripts.Length - 1; i >= 0; i--)
                {
                    Aspose.Html.Dom.Element script = scripts[i];
                    if (script.ParentNode != null)
                    {
                        script.ParentNode.RemoveChild(script);
                    }
                }

                // Remove all image elements (demonstration)
                Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");
                for (int i = images.Length - 1; i >= 0; i--)
                {
                    Aspose.Html.Dom.Element img = images[i];
                    if (img.ParentNode != null)
                    {
                        img.ParentNode.RemoveChild(img);
                    }
                }

                // List script src attributes before removal (optional demonstration)
                // (Re-loading a fresh document to show src values)
                using (Aspose.Html.HTMLDocument tempDoc = new Aspose.Html.HTMLDocument(inputPath))
                {
                    Aspose.Html.Collections.HTMLCollection scriptElements = tempDoc.GetElementsByTagName("script");
                    for (int i = 0; i < scriptElements.Length; i++)
                    {
                        Aspose.Html.Dom.Element scriptElement = scriptElements[i];
                        string src = scriptElement.GetAttribute("src");
                        if (!string.IsNullOrEmpty(src))
                        {
                            Console.WriteLine("Script src: " + src);
                        }
                    }
                }

                // Remove comments recursively
                RemoveComments(document.DocumentElement);

                // Save document
                document.Save(outputPath);
            }

            // Demonstrate creating a document from HTML string
            string htmlContent = "<html><body><p>Inline HTML document</p></body></html>";
            using (Aspose.Html.HTMLDocument docFromString = new Aspose.Html.HTMLDocument(htmlContent, ""))
            {
                Aspose.Html.Collections.HTMLCollection elements = docFromString.GetElementsByTagName("*");
                for (int i = 0; i < elements.Length; i++)
                {
                    Aspose.Html.Dom.Element element = elements[i];
                    Console.WriteLine("Tag: " + element.TagName);
                }
            }

            Console.WriteLine("Processing completed. Output saved to " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void RemoveComments(Aspose.Html.Dom.Node node)
    {
        Aspose.Html.Dom.Node child = node.FirstChild;
        while (child != null)
        {
            Aspose.Html.Dom.Node next = child.NextSibling;

            // Use NodeName to identify comment nodes
            if (child.NodeName == "#comment")
            {
                node.RemoveChild(child);
            }
            else
            {
                RemoveComments(child);
            }

            child = next;
        }
    }
}