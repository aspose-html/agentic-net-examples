// Merge multiple HTML files by appending their body sections into a single document.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            string[] inputFiles = { "input1.html", "input2.html", "input3.html" };
            string outputFile = "merged.html";

            Aspose.Html.HTMLDocument mergedDoc = new Aspose.Html.HTMLDocument();
            Aspose.Html.HTMLElement mergedBody = mergedDoc.Body;

            foreach (string file in inputFiles)
            {
                Aspose.Html.HTMLDocument srcDoc = new Aspose.Html.HTMLDocument(file);
                Aspose.Html.HTMLElement srcBody = (Aspose.Html.HTMLElement)srcDoc.GetElementsByTagName("body").First();

                foreach (Aspose.Html.Dom.Node node in srcBody.ChildNodes)
                {
                    Aspose.Html.Dom.Node imported = mergedDoc.ImportNode(node, true);
                    mergedBody.AppendChild(imported);
                }
            }

            mergedDoc.Save(outputFile);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}