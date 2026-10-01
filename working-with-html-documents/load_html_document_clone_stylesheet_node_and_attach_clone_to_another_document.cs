// Load an HTML document, clone its stylesheet node, and attach the clone to another document.

using System;
using System.IO;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath1 = "doc1.html";
            string outputPath2 = "doc2.html";

            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><style>body {font-family:Arial;}</style></head><body><p>Hello</p></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            HTMLDocument document1 = new HTMLDocument(inputPath);
            Element styleElement = Enumerable.First(document1.GetElementsByTagName("style")) as Element;
            Node clonedStyle = styleElement.CloneNode(true);
            document1.Save(outputPath1);

            HTMLDocument document2 = new HTMLDocument();
            Element head2 = Enumerable.First(document2.GetElementsByTagName("head")) as Element;
            if (head2 == null)
            {
                head2 = document2.CreateElement("head");
                document2.DocumentElement.InsertBefore(head2, document2.Body);
            }

            head2.AppendChild(clonedStyle);
            document2.Save(outputPath2);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}