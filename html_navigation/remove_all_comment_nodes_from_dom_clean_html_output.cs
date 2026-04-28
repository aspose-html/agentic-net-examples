// Remove all comment nodes from the DOM to produce a clean HTML output.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            using (HTMLDocument document = new HTMLDocument(inputPath))
            {
                var rootChildren = document.ChildNodes;
                for (int i = rootChildren.Length - 1; i >= 0; i--)
                {
                    var node = rootChildren[i];
                    if (node is Comment)
                        document.RemoveChild(node);
                }

                HTMLCollection elements = document.GetElementsByTagName("*");
                foreach (Element element in elements)
                {
                    var children = element.ChildNodes;
                    for (int i = children.Length - 1; i >= 0; i--)
                    {
                        var child = children[i];
                        if (child is Comment)
                            element.RemoveChild(child);
                    }
                }

                document.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}