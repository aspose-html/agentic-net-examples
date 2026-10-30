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

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            AddParagraphComments(document);

            document.Save(outputPath);
            Console.WriteLine($"Document saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void AddParagraphComments(Aspose.Html.HTMLDocument document)
    {
        int lineNumber = 1;
        void Traverse(Aspose.Html.Dom.Node node)
        {
            var child = node.FirstChild;
            while (child != null)
            {
                var next = child.NextSibling;
                if (child.NodeName == "p")
                {
                    var comment = document.CreateComment($"Line {lineNumber}");
                    var parent = child.ParentNode;
                    if (parent != null)
                    {
                        parent.InsertBefore(comment, child);
                    }
                    lineNumber++;
                }
                else
                {
                    Traverse(child);
                }
                child = next;
            }
        }

        Traverse(document.DocumentElement);
    }
}