// Remove all Markdown comments from the document to produce a clean version without annotations.

namespace Example
{
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
                    string sampleHtml = "<!DOCTYPE html><html><head><!-- head comment --></head><body><!-- body comment --><p>Hello World</p></body></html>";
                    System.IO.File.WriteAllText(inputPath, sampleHtml);
                }

                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
                RemoveComments(document.DocumentElement);
                document.Save(outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
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