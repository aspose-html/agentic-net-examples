// Load multiple HTML documents asynchronously, merge their head sections, and produce a combined document.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

namespace MergeHtmlHeads
{
    class Program
    {
        static void Main()
        {
            try
            {
                string[] paths = new string[] { "input1.html", "input2.html" };
                string outputPath = "merged.html";

                using (Aspose.Html.HTMLDocument combinedDocument = new Aspose.Html.HTMLDocument())
                {
                    Aspose.Html.HTMLElement combinedHead = (Aspose.Html.HTMLElement)combinedDocument.GetElementsByTagName("head")[0];

                    foreach (string path in paths)
                    {
                        using (Aspose.Html.HTMLDocument sourceDocument = new Aspose.Html.HTMLDocument(path))
                        {
                            Aspose.Html.HTMLElement sourceHead = (Aspose.Html.HTMLElement)sourceDocument.GetElementsByTagName("head")[0];
                            foreach (Aspose.Html.Dom.Node node in sourceHead.ChildNodes)
                            {
                                Aspose.Html.Dom.Node imported = combinedDocument.ImportNode(node, true);
                                combinedHead.AppendChild(imported);
                            }
                        }
                    }

                    combinedDocument.Save(outputPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}