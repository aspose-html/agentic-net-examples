// Detect and remove empty elements that contain no child nodes or text content.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllText(inputPath, "<html><body><div></div><p>Text</p><span>   </span></body></html>");
            }

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                RemoveEmptyElements(document.DocumentElement);
                document.Save(outputPath);
            }

            System.Console.WriteLine("Empty elements removed and saved to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }

    static void RemoveEmptyElements(Aspose.Html.Dom.Node node)
    {
        var child = node.FirstChild;
        while (child != null)
        {
            var next = child.NextSibling;
            RemoveEmptyElements(child);

            if (child.NodeName != "#text" && child.NodeName != "#comment")
            {
                bool hasNoChildren = child.FirstChild == null;
                bool hasNoText = string.IsNullOrWhiteSpace(child.TextContent);
                if (hasNoChildren && hasNoText)
                {
                    node.RemoveChild(child);
                }
            }

            child = next;
        }
    }
}