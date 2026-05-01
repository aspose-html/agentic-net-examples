// Load an HTML document, clone its stylesheet node, and attach the clone to another document.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for the source HTML, the target HTML, and the result file
            string sourcePath = "source.html";
            string targetPath = "target.html";
            string outputPath = "result.html";

            // Load the source document (contains the stylesheet to copy)
            Aspose.Html.HTMLDocument sourceDoc = new Aspose.Html.HTMLDocument(sourcePath);

            // Load the target document (where the cloned stylesheet will be attached)
            Aspose.Html.HTMLDocument targetDoc = new Aspose.Html.HTMLDocument(targetPath);

            // Locate the first <style> element in the source document
            var styleElement = sourceDoc.QuerySelector("style") as Aspose.Html.Dom.Element;
            if (styleElement != null)
            {
                // Clone the style element (deep clone to include its content)
                var clonedStyle = (Aspose.Html.Dom.Element)styleElement.CloneNode(true);

                // Find the <head> element in the target document
                var head = targetDoc.QuerySelector("head") as Aspose.Html.Dom.Element;
                if (head != null)
                {
                    // Append the cloned stylesheet to the existing head
                    head.AppendChild(clonedStyle);
                }
                else
                {
                    // If the target document lacks a head, create one and insert it before the body
                    var newHead = (Aspose.Html.Dom.Element)targetDoc.CreateElement("head");
                    var body = targetDoc.Body;
                    targetDoc.DocumentElement.InsertBefore(newHead, body);
                    newHead.AppendChild(clonedStyle);
                }
            }

            // Save the modified target document
            targetDoc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}