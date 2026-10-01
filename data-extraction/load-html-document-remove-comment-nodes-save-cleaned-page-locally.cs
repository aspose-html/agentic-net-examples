// Load an HTML document, remove all comment nodes, and save the cleaned page locally.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.html";
                string outputPath = "output.html";

                if (!System.IO.File.Exists(inputPath))
                {
                    string sampleHtml = "<!DOCTYPE html><html><head><!-- Head comment --><title>Sample</title></head><body><!-- Body comment --><p>Hello World</p></body></html>";
                    System.IO.File.WriteAllText(inputPath, sampleHtml);
                }

                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
                RemoveComments(document.DocumentElement);
                document.Save(outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
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
}