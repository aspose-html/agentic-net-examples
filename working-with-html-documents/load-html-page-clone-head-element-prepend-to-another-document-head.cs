// Load an HTML page, clone its head element, and prepend it to another document's head.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "source.html";
            string targetPath = "target.html";
            string outputPath = "result.html";

            // Create minimal sample files if they do not exist
            if (!System.IO.File.Exists(sourcePath))
            {
                System.IO.File.WriteAllText(sourcePath,
                    "<html><head><title>Source</title></head><body><p>Source body</p></body></html>");
            }

            if (!System.IO.File.Exists(targetPath))
            {
                System.IO.File.WriteAllText(targetPath,
                    "<html><head><title>Target</title></head><body><p>Target body</p></body></html>");
            }

            // Load the source and target documents
            Aspose.Html.HTMLDocument sourceDoc = new Aspose.Html.HTMLDocument(sourcePath);
            Aspose.Html.HTMLDocument targetDoc = new Aspose.Html.HTMLDocument(targetPath);

            // Get the <head> element from the source document
            Aspose.Html.HTMLElement sourceHead = sourceDoc.QuerySelector("head") as Aspose.Html.HTMLElement;
            if (sourceHead == null)
            {
                Console.WriteLine("Source document does not contain a <head> element.");
                return;
            }

            // Clone the source <head> (deep clone)
            Aspose.Html.Dom.Node clonedNode = sourceHead.CloneNode(true);
            Aspose.Html.HTMLElement clonedHead = clonedNode as Aspose.Html.HTMLElement;

            // Get (or create) the <head> element in the target document
            Aspose.Html.HTMLElement targetHead = targetDoc.QuerySelector("head") as Aspose.Html.HTMLElement;
            if (targetHead == null)
            {
                targetHead = targetDoc.CreateElement("head") as Aspose.Html.HTMLElement;
                targetDoc.DocumentElement.InsertBefore(targetHead, targetDoc.Body);
            }

            // Prepend the cloned head to the target document's head
            targetHead.InsertBefore(clonedHead, targetHead.FirstChild);

            // Save the modified target document
            targetDoc.Save(outputPath);
            Console.WriteLine($"Result saved to {outputPath}");
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}