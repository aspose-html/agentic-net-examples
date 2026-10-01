// Replace double spaces with single spaces in all text nodes to improve readability.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><p>This  is  a  test.</p><div>Another  line  with  double  spaces.</div></body></html>";
            using Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "");

            void ProcessNode(Aspose.Html.Dom.Node node)
            {
                for (Aspose.Html.Dom.Node child = node.FirstChild; child != null; )
                {
                    Aspose.Html.Dom.Node next = child.NextSibling;
                    if (child is Aspose.Html.Dom.Text textNode)
                    {
                        string txt = textNode.TextContent;
                        while (txt.Contains("  "))
                        {
                            txt = txt.Replace("  ", " ");
                        }
                        textNode.TextContent = txt;
                    }
                    else
                    {
                        ProcessNode(child);
                    }
                    child = next;
                }
            }

            ProcessNode(document.Body);

            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine($"Processed HTML saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}