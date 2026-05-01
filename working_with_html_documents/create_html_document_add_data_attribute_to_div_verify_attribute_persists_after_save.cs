// Create an HTML document, add a data‑attribute to a div, and verify attribute persists after save.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Define output file path
                string outputPath = "output.html";

                // Create a new empty HTML document
                HTMLDocument doc = new HTMLDocument();

                // Access the body element
                HTMLElement body = doc.Body;

                // Create a <div> element
                HTMLElement div = (HTMLElement)doc.CreateElement("div");

                // Add a custom data-attribute to the <div>
                div.SetAttribute("data-custom", "myValue");

                // Append the <div> to the body
                body.AppendChild(div);

                // Save the document to a file
                doc.Save(outputPath);

                // Load the saved document to verify the attribute persists
                HTMLDocument loadedDoc = new HTMLDocument(outputPath);
                HTMLElement loadedDiv = loadedDoc.QuerySelector("div") as HTMLElement;

                // Retrieve the data-attribute value
                string attributeValue = loadedDiv?.GetAttribute("data-custom");

                // Output verification result
                Console.WriteLine($"Data attribute value after reload: {attributeValue}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}