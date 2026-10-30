// Load an HTML document, clone its stylesheet node, and attach the clone to another document.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML with a stylesheet
            string inputHtml = "<!DOCTYPE html><html><head><style>body { background-color: lightblue; }</style></head><body><p>Hello</p></body></html>";

            // Load source document (inline HTML)
            Aspose.Html.HTMLDocument sourceDoc = new Aspose.Html.HTMLDocument(inputHtml, "about:blank");

            // Locate the <style> element
            Aspose.Html.Dom.Element styleElem = (Aspose.Html.Dom.Element)sourceDoc.QuerySelector("style");
            if (styleElem == null)
            {
                Console.WriteLine("No <style> element found in the source document.");
                return;
            }

            // Clone the stylesheet node
            Aspose.Html.Dom.Element clonedStyle = (Aspose.Html.Dom.Element)styleElem.CloneNode(true);

            // Create target document (empty HTML skeleton)
            Aspose.Html.HTMLDocument targetDoc = new Aspose.Html.HTMLDocument("<!DOCTYPE html><html><head></head><body></body></html>", "about:blank");

            // Ensure the target document has a <head> element
            Aspose.Html.Dom.Element headElem = (Aspose.Html.Dom.Element)targetDoc.QuerySelector("head");
            if (headElem == null)
            {
                Aspose.Html.Dom.Element newHead = (Aspose.Html.Dom.Element)targetDoc.CreateElement("head");
                Aspose.Html.Dom.Element bodyElem = (Aspose.Html.Dom.Element)targetDoc.QuerySelector("body");
                targetDoc.DocumentElement.InsertBefore(newHead, bodyElem);
                headElem = newHead;
            }

            // Attach the cloned stylesheet to the target document's <head>
            headElem.AppendChild(clonedStyle);

            // Save both documents
            string sourcePath = Path.Combine(Directory.GetCurrentDirectory(), "source.html");
            string targetPath = Path.Combine(Directory.GetCurrentDirectory(), "target.html");
            sourceDoc.Save(sourcePath);
            targetDoc.Save(targetPath);

            Console.WriteLine($"Source document saved to: {sourcePath}");
            Console.WriteLine($"Target document saved to: {targetPath}");
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}