// Load an HTML document, clone its body, and insert the clone into a new document's body.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Load the source HTML document
            HTMLDocument sourceDoc = new HTMLDocument(inputPath);

            // Clone the body element (deep clone)
            HTMLElement clonedBody = (HTMLElement)sourceDoc.Body.CloneNode(true);

            // Create a new empty HTML document
            HTMLDocument newDoc = new HTMLDocument();

            // Insert the cloned body into the new document
            newDoc.Body = clonedBody;

            // Save the new document
            newDoc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}