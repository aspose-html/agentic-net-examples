// Replace inline code spans with emphasized text to demonstrate alternative formatting options.

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><p>This is a <code>sample</code> code.</p></body></html>";
            string baseUri = "";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            var codeElements = document.GetElementsByTagName("code");
            List<Aspose.Html.HTMLElement> elementsToReplace = new List<Aspose.Html.HTMLElement>();

            foreach (Aspose.Html.HTMLElement code in codeElements)
            {
                elementsToReplace.Add(code);
            }

            foreach (Aspose.Html.HTMLElement code in elementsToReplace)
            {
                Aspose.Html.Dom.Element emElement = document.CreateElement("em");
                emElement.TextContent = code.TextContent;
                Aspose.Html.Dom.Node parent = code.ParentNode;
                parent.ReplaceChild(emElement, code);
            }

            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine("Processed HTML saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}