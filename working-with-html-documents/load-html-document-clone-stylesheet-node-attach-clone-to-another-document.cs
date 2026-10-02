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
            // Prepare sample HTML content with a stylesheet
            string htmlContent = "<!DOCTYPE html><html><head><style>body { background-color: #f0f0f0; }</style></head><body><p>Hello World</p></body></html>";

            // Load the first document from inline content
            Aspose.Html.HTMLDocument doc1 = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Locate the <style> element in the first document
            Aspose.Html.Dom.Element styleElement = System.Linq.Enumerable.FirstOrDefault(
                System.Linq.Enumerable.Cast<Aspose.Html.Dom.Element>(doc1.GetElementsByTagName("style"))
            );

            if (styleElement == null)
                throw new InvalidOperationException("Style element not found in the source document.");

            // Clone the stylesheet node (deep clone)
            Aspose.Html.Dom.Element clonedStyle = (Aspose.Html.Dom.Element)styleElement.CloneNode(true);

            // Create a second document (empty HTML skeleton)
            string emptyHtml = "<!DOCTYPE html><html><head></head><body></body></html>";
            Aspose.Html.HTMLDocument doc2 = new Aspose.Html.HTMLDocument(emptyHtml, "about:blank");

            // Locate the <head> element in the second document
            Aspose.Html.Dom.Element headElement = System.Linq.Enumerable.FirstOrDefault(
                System.Linq.Enumerable.Cast<Aspose.Html.Dom.Element>(doc2.GetElementsByTagName("head"))
            );

            if (headElement == null)
                throw new InvalidOperationException("Head element not found in the target document.");

            // Attach the cloned stylesheet to the second document's head
            headElement.AppendChild(clonedStyle);

            // Define output paths
            string outputPath1 = Path.Combine(Directory.GetCurrentDirectory(), "doc1.html");
            string outputPath2 = Path.Combine(Directory.GetCurrentDirectory(), "doc2.html");

            // Save both documents
            doc1.Save(outputPath1);
            doc2.Save(outputPath2);

            Console.WriteLine("Documents saved successfully:");
            Console.WriteLine(outputPath1);
            Console.WriteLine(outputPath2);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}