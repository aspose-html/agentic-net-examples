// Wrap each paragraph element inside a div with a specific CSS class for layout control.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>First paragraph.</p><p>Second paragraph.</p></body></html>";
            // Load HTML from string (base URI is not used here)
            HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");

            // Get all paragraph elements
            var paragraphs = document.GetElementsByTagName("p");
            foreach (Element paragraph in paragraphs)
            {
                // Create a new div element
                Element wrapperDiv = document.CreateElement("div");
                wrapperDiv.SetAttribute("class", "layout-wrapper");

                // Insert the div before the paragraph
                Element parent = paragraph.ParentNode as Element;
                if (parent != null)
                {
                    parent.InsertBefore(wrapperDiv, paragraph);
                    // Move the paragraph inside the new div
                    wrapperDiv.AppendChild(paragraph);
                }
            }

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine($"Document saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}