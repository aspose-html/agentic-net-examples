// Replace inline code spans with emphasized text to demonstrate alternative formatting options.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with inline code spans
            string htmlContent = "<html><body><p>This is a <code>sample</code> code snippet with <code>inline</code> elements.</p></body></html>";
            string baseUri = "about:blank";

            // Load HTML document from string content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            // Get all <code> elements
            Aspose.Html.Collections.HTMLCollection codeCollection = document.GetElementsByTagName("code");

            // Copy elements to a list to avoid modification during iteration
            List<Aspose.Html.Dom.Element> codeElements = new List<Aspose.Html.Dom.Element>();
            for (int i = 0; i < codeCollection.Length; i++)
            {
                codeElements.Add(codeCollection[i]);
            }

            // Replace each <code> with <em> containing the same text
            foreach (Aspose.Html.Dom.Element codeElem in codeElements)
            {
                Aspose.Html.HTMLElement emElem = (Aspose.Html.HTMLElement)document.CreateElement("em");
                emElem.TextContent = codeElem.TextContent;
                codeElem.ParentNode.ReplaceChild(emElem, codeElem);
            }

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);

            System.Console.WriteLine("HTML processing completed. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}