// Apply a custom NodeFilter to extract only script tags while ignoring other elements.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Traversal;
using Aspose.Html.Dom.Traversal.Filters;

class ScriptTagFilter : NodeFilter
{
    public override short AcceptNode(Node n)
    {
        return string.Equals("script", n.LocalName, StringComparison.OrdinalIgnoreCase) ? FILTER_ACCEPT : FILTER_SKIP;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML content
            string htmlContent = @"<html>
<head>
    <script src='a.js'></script>
</head>
<body>
    <script>console.log('test');</script>
    <div>Some other content</div>
</body>
</html>";

            // Write sample HTML to a temporary file
            string inputPath = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(inputPath, htmlContent);

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Create a TreeWalker with the custom filter to accept only <script> elements
            ITreeWalker iterator = document.CreateTreeWalker(
                document,
                NodeFilter.SHOW_ALL,
                new ScriptTagFilter()
            );

            // Iterate and output script elements
            while (iterator.NextNode() != null)
            {
                Element scriptElement = (Element)iterator.CurrentNode;
                Console.WriteLine(scriptElement.OuterHTML);
            }

            // Clean up temporary file
            if (File.Exists(inputPath))
            {
                File.Delete(inputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}