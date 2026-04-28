// Create a <style> element with CSS rules, append it to the HTML head, and generate the final document.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Rendering;

class Program
{
    static void Main()
    {
        try
        {
            // Input HTML file path
            string inputPath = "input.html";
            // Output HTML file path
            string outputPath = "output.html";
            // CSS rules to be added
            string css = "body { background-color: #f0f0f0; }";

            // Load the existing HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Create a <style> element
            HTMLStyleElement styleElement = (HTMLStyleElement)document.CreateElement("style");

            // Create a text node containing the CSS and append it to the style element
            Text textNode = document.CreateTextNode(css);
            styleElement.AppendChild(textNode);

            // Retrieve the <head> element; create it if it does not exist
            HTMLElement head = document.QuerySelector("head") as HTMLElement;
            if (head == null)
            {
                head = (HTMLElement)document.CreateElement("head");
                document.DocumentElement.InsertBefore(head, document.Body);
            }

            // Append the style element to the head
            head.AppendChild(styleElement);

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}