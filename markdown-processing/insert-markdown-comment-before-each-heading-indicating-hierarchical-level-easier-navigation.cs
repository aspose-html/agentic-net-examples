// Insert a Markdown comment before each heading indicating its hierarchical level for easier navigation.

using System;

namespace AsposeHtmlExample
{
    class Program
    {
        // # Setup
        static void Main()
        {
            try
            {
                // # Define paths
                string inputPath = "input.html";
                string outputPath = "output.html";

                // # Load document
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

                // ## Remove comments
                RemoveComments(document.DocumentElement);

                // # Save result
                document.Save(outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // ## Recursive comment removal
        static void RemoveComments(Aspose.Html.Dom.Node node)
        {
            var child = node.FirstChild;
            while (child != null)
            {
                var next = child.NextSibling;

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
}