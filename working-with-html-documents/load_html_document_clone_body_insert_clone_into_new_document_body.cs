// Load an HTML document, clone its body, and insert the clone into a new document's body.

using System;
using System.IO;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample input file
            string inputPath = "input.html";
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello, World!</p></body></html>");
            }

            string outputPath = "output.html";

            // Configure behavior
            Aspose.Html.Configuration config = new Aspose.Html.Configuration();
            config.Security |= Aspose.Html.Sandbox.Scripts;

            // Load source document
            Aspose.Html.HTMLDocument srcDoc = new Aspose.Html.HTMLDocument(inputPath, config);

            // Access source body element
            Aspose.Html.HTMLElement srcBody = (Aspose.Html.HTMLElement)System.Linq.Enumerable.First(srcDoc.GetElementsByTagName("body"));

            // Clone the body (deep clone)
            Aspose.Html.HTMLElement clonedBody = (Aspose.Html.HTMLElement)srcBody.CloneNode(true);

            // Create a new empty document
            Aspose.Html.HTMLDocument newDoc = new Aspose.Html.HTMLDocument();

            // Access new document's body
            Aspose.Html.HTMLElement newBody = (Aspose.Html.HTMLElement)System.Linq.Enumerable.First(newDoc.GetElementsByTagName("body"));

            // Insert cloned content into the new document's body
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