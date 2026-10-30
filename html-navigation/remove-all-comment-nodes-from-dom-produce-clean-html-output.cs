// Remove all comment nodes from the DOM to produce a clean HTML output.

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
                string sample = "<!DOCTYPE html><html><head><!-- head comment --><title>Test</title></head><body><!-- body comment --><p>Hello World</p><!-- another comment --></body></html>";
                System.IO.File.WriteAllText(inputPath, sample);
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            RemoveComments(document.DocumentElement);
            document.Save(outputPath);
            Console.WriteLine("Comments removed and saved to " + outputPath);
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