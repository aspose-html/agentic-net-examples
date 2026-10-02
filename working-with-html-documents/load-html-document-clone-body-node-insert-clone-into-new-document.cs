// Load an HTML document, clone its body node, and insert the clone into a new document.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!System.IO.File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello World</p></body></html>";
                System.IO.File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the source HTML document
            Aspose.Html.HTMLDocument srcDoc = new Aspose.Html.HTMLDocument(inputPath);

            // Get the <body> element from the source document
            Aspose.Html.HTMLElement srcBody = (Aspose.Html.HTMLElement)srcDoc.GetElementsByTagName("body")[0];

            // Clone the body node (deep clone)
            Aspose.Html.Dom.Node clonedBody = srcBody.CloneNode(true);

            // Create a new empty HTML document
            Aspose.Html.HTMLDocument newDoc = new Aspose.Html.HTMLDocument();

            // Remove the default body from the new document
            Aspose.Html.HTMLElement defaultBody = newDoc.Body;
            defaultBody.ParentNode.RemoveChild(defaultBody);

            // Append the cloned body to the new document's <html> element
            newDoc.DocumentElement.AppendChild(clonedBody);

            // Save the new document to a file
            newDoc.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}