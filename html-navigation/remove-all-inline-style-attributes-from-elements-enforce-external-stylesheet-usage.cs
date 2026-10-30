// Remove all inline style attributes from elements to enforce external stylesheet usage.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with inline styles
            string inputHtml = "<html><head><title>Sample</title></head><body><div style=\"color:red;\">Hello</div><p style=\"font-size:12px;\">World</p></body></html>";
            string baseUri = "about:blank";

            // Load HTML document from string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputHtml, baseUri);

            // Select all elements that have a style attribute
            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("[style]");

            // Remove the inline style attribute from each element
            for (int i = 0; i < elements.Length; i++)
            {
                Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)elements[i];
                element.RemoveAttribute("style");
            }

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);

            Console.WriteLine($"Document saved to '{Path.GetFullPath(outputPath)}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}