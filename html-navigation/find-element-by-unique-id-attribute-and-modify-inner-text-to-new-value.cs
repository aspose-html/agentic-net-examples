// Find an element by its unique ID attribute and modify its inner text to a new value.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Create a simple HTML document with an element that has a unique ID.
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><div id=\"myElement\">Old text</div></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Find the element by its ID using a CSS selector.
            Aspose.Html.HTMLElement element = document.QuerySelector("#myElement") as Aspose.Html.HTMLElement;
            if (element != null)
            {
                // Modify the inner text of the element.
                element.InnerHTML = "New text";
            }

            // Save the modified document to a file.
            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine($"Document saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}