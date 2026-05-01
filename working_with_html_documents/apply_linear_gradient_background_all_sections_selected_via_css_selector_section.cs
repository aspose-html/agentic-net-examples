// Apply a linear gradient background to all sections selected via CSS selector ".section".

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Input and output HTML file paths
            string inputPath = "input.html";
            string outputPath = "output.html";

            // CSS rule that applies a linear gradient to elements with class "section"
            string css = ".section { background: linear-gradient(to right, #ff0000, #00ff00); }";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Create a <style> element and add the CSS rule as its text content
            HTMLStyleElement styleElement = (HTMLStyleElement)document.CreateElement("style");
            Aspose.Html.Dom.Text textNode = document.CreateTextNode(css);
            styleElement.AppendChild(textNode);

            // Ensure the document has a <head> element; create one if missing
            HTMLElement head = document.QuerySelector("head") as HTMLElement;
            if (head == null)
            {
                head = (HTMLElement)document.CreateElement("head");
                document.DocumentElement.InsertBefore(head, document.Body);
            }

            // Append the <style> element to the <head>
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