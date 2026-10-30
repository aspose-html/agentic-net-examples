// Wrap each paragraph element inside a div with a specific CSS class for layout control.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><head><title>Sample</title></head><body><p>First paragraph.</p><p>Second paragraph.</p></body></html>";
            // Load document from string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get all paragraph elements
            Aspose.Html.Collections.HTMLCollection paragraphs = document.GetElementsByTagName("p");
            // Iterate over a copy of the collection length because we will modify the DOM
            int count = paragraphs.Length;
            for (int i = 0; i < count; i++)
            {
                Aspose.Html.HTMLElement paragraph = (Aspose.Html.HTMLElement)paragraphs[i];

                // Create wrapper div with specific CSS class
                Aspose.Html.HTMLElement wrapperDiv = (Aspose.Html.HTMLElement)document.CreateElement("div");
                wrapperDiv.SetAttribute("class", "layout-wrapper");

                // Insert wrapper div in place of the paragraph
                Node parent = paragraph.ParentNode;
                parent.ReplaceChild(wrapperDiv, paragraph);
                // Move paragraph inside the wrapper div
                wrapperDiv.AppendChild(paragraph);
            }

            // Save modified document
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
            document.Save(outputPath);
            System.Console.WriteLine("Document saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}