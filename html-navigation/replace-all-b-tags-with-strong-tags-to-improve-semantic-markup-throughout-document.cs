// Replace all <b> tags with <strong> tags to improve semantic markup throughout the document.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with <b> tags
            string htmlContent = "<html><body><p>This is <b>bold</b> and <b>strong</b> text.</p></body></html>";
            // Load the HTML document from the string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get all <b> elements
            Aspose.Html.Collections.HTMLCollection bCollection = document.GetElementsByTagName("b");
            List<Aspose.Html.HTMLElement> bElements = new List<Aspose.Html.HTMLElement>();
            for (int i = 0; i < bCollection.Length; i++)
            {
                bElements.Add((Aspose.Html.HTMLElement)bCollection[i]);
            }

            // Replace each <b> with <strong>
            foreach (Aspose.Html.HTMLElement bElement in bElements)
            {
                Aspose.Html.HTMLElement strongElement = (Aspose.Html.HTMLElement)document.CreateElement("strong");
                strongElement.InnerHTML = bElement.InnerHTML;
                bElement.ParentNode.ReplaceChild(strongElement, bElement);
            }

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine("Document saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}