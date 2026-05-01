// Load an HTML page, clone its head element, and prepend it to another document's head.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Paths to the source HTML, target HTML and the result file
            string sourcePath = "source.html";
            string targetPath = "target.html";
            string outputPath = "result.html";

            // Load the source and target documents
            HTMLDocument sourceDoc = new HTMLDocument(sourcePath);
            HTMLDocument targetDoc = new HTMLDocument(targetPath);

            // Get the <head> element from the source document
            HTMLElement sourceHead = sourceDoc.QuerySelector("head") as HTMLElement;
            if (sourceHead == null)
                throw new InvalidOperationException("Source document does not contain a <head> element.");

            // Clone the source <head> (deep clone)
            HTMLElement clonedHead = sourceHead.CloneNode(true) as HTMLElement;

            // Get (or create) the <head> element in the target document
            HTMLElement targetHead = targetDoc.QuerySelector("head") as HTMLElement;
            if (targetHead == null)
            {
                // Create a new <head> element and insert it before the <body>
                targetHead = targetDoc.CreateElement("head") as HTMLElement;
                targetDoc.DocumentElement.InsertBefore(targetHead, targetDoc.Body);
            }

            // Prepend the cloned head to the target head
            // If the target head already has children, insert before the first child; otherwise, append
            if (targetHead.FirstChild != null)
                targetHead.InsertBefore(clonedHead, targetHead.FirstChild);
            else
                targetHead.AppendChild(clonedHead);

            // Save the modified target document
            targetDoc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}