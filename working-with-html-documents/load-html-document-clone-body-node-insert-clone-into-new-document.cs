// Load an HTML document, clone its body node, and insert the clone into a new document.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample input HTML file
            string inputPath = "input.html";
            string originalOutputPath = "original.html";
            string clonedOutputPath = "cloned.html";

            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello World</p></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the original HTML document
            HTMLDocument document = new HTMLDocument(inputPath);
            document.Save(originalOutputPath);

            // Access the body element
            HTMLCollection bodyCollection = document.GetElementsByTagName("body");
            HTMLElement body = (HTMLElement)bodyCollection[0];

            // Clone the body node (deep clone)
            HTMLElement clonedBody = (HTMLElement)body.CloneNode(true);

            // Create a new empty HTML document
            HTMLDocument newDocument = new HTMLDocument();

            // Insert the cloned body into the new document
            newDocument.Body.AppendChild(clonedBody);

            // Save the new document
            newDocument.Save(clonedOutputPath);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}