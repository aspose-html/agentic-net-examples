// Load an HTML document, remove all comment nodes, and save the cleaned page locally.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

namespace RemoveCommentsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.html";
                string outputPath = "output.html";

                using (HTMLDocument document = new HTMLDocument(inputPath))
                {
                    RemoveComments(document);
                    document.Save(outputPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void RemoveComments(Node node)
        {
            var childNodes = node.ChildNodes;
            for (int i = childNodes.Length - 1; i >= 0; i--)
            {
                var child = childNodes[i];
                if (child is Comment)
                {
                    node.RemoveChild(child);
                }
                else
                {
                    RemoveComments(child);
                }
            }
        }
    }
}