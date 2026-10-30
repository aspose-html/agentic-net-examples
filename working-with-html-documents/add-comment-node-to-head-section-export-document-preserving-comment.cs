// Add a comment node to the head section, then export the document preserving the comment.

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
            string inputPath = "sample.html";
            string outputPath = "output.html";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello World</p></body></html>");
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Retrieve the <head> element
            HTMLCollection headCollection = document.DocumentElement.GetElementsByTagName("head");
            if (headCollection.Length == 0)
            {
                throw new InvalidOperationException("The document does not contain a <head> element.");
            }
            Aspose.Html.HTMLElement head = (Aspose.Html.HTMLElement)headCollection[0];

            // Create a comment node and add it to the head
            Aspose.Html.Dom.Comment commentNode = document.CreateComment(" This is a comment added to the head ");
            head.AppendChild(commentNode);

            // Save the modified document preserving the comment
            document.Save(outputPath);
            Console.WriteLine($"Document saved to '{outputPath}' with comment preserved.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}