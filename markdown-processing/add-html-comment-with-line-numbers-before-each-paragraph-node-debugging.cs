// Add an HTML comment containing line numbers before each paragraph node for debugging purposes.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><p>First paragraph.</p><div><p>Second paragraph.</p></div></body></html>");
            }

            var document = new Aspose.Html.HTMLDocument(inputPath);

            int paragraphIndex = 1;
            AddParagraphComments(document.DocumentElement, document, ref paragraphIndex);

            document.Save(outputPath);
            Console.WriteLine($"Document saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void AddParagraphComments(Aspose.Html.Dom.Node node, Aspose.Html.HTMLDocument doc, ref int index)
    {
        var child = node.FirstChild;
        while (child != null)
        {
            var next = child.NextSibling;

            if (child.NodeName == "p")
            {
                var comment = doc.CreateComment($" Paragraph {index} ");
                node.InsertBefore(comment, child);
                index++;
            }

            AddParagraphComments(child, doc, ref index);
            child = next;
        }
    }
}