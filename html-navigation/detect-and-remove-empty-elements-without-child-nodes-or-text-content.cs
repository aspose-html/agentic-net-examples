// Detect and remove empty elements that contain no child nodes or text content.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "output.html";

            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllText(inputPath, "<html><body><div></div><p>Text</p><span>   </span></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            RemoveEmptyElements(document.DocumentElement);

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void RemoveEmptyElements(Aspose.Html.Dom.Node node)
    {
        var child = node.FirstChild;
        while (child != null)
        {
            var next = child.NextSibling;

            // Recursively process child nodes first
            RemoveEmptyElements(child);

            // Check if the child is an element and is empty
            if (child is Aspose.Html.Dom.Element element)
            {
                bool hasNoChildren = element.FirstChild == null;
                bool hasNoText = string.IsNullOrWhiteSpace(element.TextContent);
                if (hasNoChildren && hasNoText)
                {
                    node.RemoveChild(child);
                }
            }

            child = next;
        }
    }
}