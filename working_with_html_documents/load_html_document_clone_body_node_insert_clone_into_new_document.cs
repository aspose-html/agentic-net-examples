// Load an HTML document, clone its body node, and insert the clone into a new document.

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
            string inputPath = "input.html";
            string outputPath = "output.html";

            HTMLDocument sourceDoc = new HTMLDocument(inputPath);
            HTMLElement sourceBody = (HTMLElement)sourceDoc.GetElementsByTagName("body").First();
            Node clonedBody = sourceBody.CloneNode(true);

            HTMLDocument newDoc = new HTMLDocument();
            HTMLElement newBody = (HTMLElement)newDoc.GetElementsByTagName("body").First();
            newBody.AppendChild(clonedBody);

            newDoc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}