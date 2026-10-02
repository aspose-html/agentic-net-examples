// Replace inline code spans with emphasized text to demonstrate alternative formatting options.

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><p>This is a <code>sample</code> text.</p></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            var codeElements = document.GetElementsByTagName("code");
            var codeList = new List<Aspose.Html.Dom.Element>();
            foreach (var elem in codeElements)
            {
                codeList.Add((Aspose.Html.Dom.Element)elem);
            }

            foreach (var codeElem in codeList)
            {
                var emElem = (Aspose.Html.Dom.Element)document.CreateElement("em");
                emElem.TextContent = codeElem.TextContent;
                var parent = codeElem.ParentNode;
                if (parent != null)
                {
                    parent.ReplaceChild(emElem, codeElem);
                }
            }

            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine("Document saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}