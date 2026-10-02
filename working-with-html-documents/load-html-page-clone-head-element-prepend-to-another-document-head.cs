// Load an HTML page, clone its head element, and prepend it to another document's head.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML files
            string sourcePath = "source.html";
            string targetPath = "target.html";
            string outputPath = "result.html";

            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(sourcePath, "<!DOCTYPE html><html><head><title>Source</title><style>body{background:#eef;}</style></head><body><p>Source document</p></body></html>");
            }

            if (!File.Exists(targetPath))
            {
                File.WriteAllText(targetPath, "<!DOCTYPE html><html><head><title>Target</title></head><body><p>Target document</p></body></html>");
            }

            // Load documents
            Aspose.Html.HTMLDocument sourceDoc = new Aspose.Html.HTMLDocument(sourcePath);
            Aspose.Html.HTMLDocument targetDoc = new Aspose.Html.HTMLDocument(targetPath);

            // Get head element from source
            Aspose.Html.HTMLElement sourceHead = sourceDoc.QuerySelector("head") as Aspose.Html.HTMLElement;
            if (sourceHead == null)
                throw new InvalidOperationException("Source document does not contain a <head> element.");

            // Clone the head element (deep clone)
            Aspose.Html.Dom.Node clonedHeadNode = sourceHead.CloneNode(true);
            Aspose.Html.HTMLElement clonedHead = clonedHeadNode as Aspose.Html.HTMLElement;
            if (clonedHead == null)
                throw new InvalidOperationException("Cloned head element is not an HTMLElement.");

            // Get head element from target
            Aspose.Html.HTMLElement targetHead = targetDoc.QuerySelector("head") as Aspose.Html.HTMLElement;
            if (targetHead == null)
                throw new InvalidOperationException("Target document does not contain a <head> element.");

            // Prepend cloned head to target document's head (insert before the existing head)
            targetDoc.DocumentElement.InsertBefore(clonedHead, targetHead);

            // Save the modified target document
            targetDoc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}