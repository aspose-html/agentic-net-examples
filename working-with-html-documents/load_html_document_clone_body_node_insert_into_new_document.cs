// Load an HTML document, clone its body node, and insert the clone into a new document.

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            Aspose.Html.HTMLDocument sourceDoc = new Aspose.Html.HTMLDocument(inputPath);
            Aspose.Html.HTMLElement sourceBody = (Aspose.Html.HTMLElement)sourceDoc.GetElementsByTagName("body").First();

            Aspose.Html.HTMLElement clonedBody = sourceBody.CloneNode(true) as Aspose.Html.HTMLElement;

            Aspose.Html.HTMLDocument newDoc = new Aspose.Html.HTMLDocument();
            Aspose.Html.HTMLElement newBody = (Aspose.Html.HTMLElement)newDoc.GetElementsByTagName("body").First();

            newBody.AppendChild(clonedBody);

            newDoc.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}