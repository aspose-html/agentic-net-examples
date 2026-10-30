// Load an HTML document, clone its body, and insert the clone into a new document's body.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample input HTML file
            string inputPath = "input.html";
            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllText(inputPath,
                    "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello World</p></body></html>");
            }

            string outputPath = "output.html";

            // Optional configuration
            Aspose.Html.Configuration config = new Aspose.Html.Configuration();

            // Load the original HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath, config);

            // Access the body element of the original document
            Aspose.Html.HTMLElement body = (Aspose.Html.HTMLElement)document.GetElementsByTagName("body")[0];

            // Clone the body (deep clone)
            Aspose.Html.Dom.Node clonedBody = body.CloneNode(true);

            // Create a new empty HTML document
            Aspose.Html.HTMLDocument newDocument = new Aspose.Html.HTMLDocument();

            // Access the body element of the new document
            Aspose.Html.HTMLElement newBody = (Aspose.Html.HTMLElement)newDocument.GetElementsByTagName("body")[0];

            // Insert the cloned body into the new document's body
            newBody.AppendChild(clonedBody);

            // Save the new document
            newDocument.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}