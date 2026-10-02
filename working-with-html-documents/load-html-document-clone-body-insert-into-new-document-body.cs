// Load an HTML document, clone its body, and insert the clone into a new document's body.

using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample input HTML file
            string inputPath = "sample.html";
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello World</p></body></html>");
            }

            string outputPath = "output.html";

            // Configure Aspose.HTML
            Aspose.Html.Configuration config = new Aspose.Html.Configuration();
            config.Security |= Aspose.Html.Sandbox.Scripts;

            // Load the source HTML document
            Aspose.Html.HTMLDocument sourceDoc = new Aspose.Html.HTMLDocument(inputPath, config);

            // Access the body element of the source document
            var sourceBody = (Aspose.Html.HTMLElement)sourceDoc.GetElementsByTagName("body").First();

            // Clone the body element (deep clone)
            var clonedBodyNode = sourceBody.CloneNode(true);
            var clonedBody = (Aspose.Html.HTMLElement)clonedBodyNode;

            // Create a new empty HTML document
            Aspose.Html.HTMLDocument newDoc = new Aspose.Html.HTMLDocument("<!DOCTYPE html><html><head><title>Cloned</title></head><body></body></html>", "about:blank");

            // Access the body of the new document
            var newBody = (Aspose.Html.HTMLElement)newDoc.GetElementsByTagName("body").First();

            // Insert the cloned body content into the new document's body
            newBody.InnerHTML = clonedBody.InnerHTML;

            // Save the new document
            newDoc.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}