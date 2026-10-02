// Highlight code block syntax by assigning a custom CSS class through node property modification.

using System;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with code blocks
            string htmlContent = "<html><head></head><body>" +
                                 "<pre><code>int x = 5;</code></pre>" +
                                 "<pre><code>Console.WriteLine(\"Hello World\");</code></pre>" +
                                 "</body></html>";

            // Load HTML document from string (base URI is required)
            HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");

            // Select all <code> elements
            NodeList elements = document.QuerySelectorAll("code");

            // Assign a custom CSS class to each code block
            foreach (HTMLElement element in elements)
            {
                element.ClassName = "custom-code";
            }

            // Create a <style> element with CSS for the custom class
            HTMLElement style = (HTMLElement)document.CreateElement("style");
            style.TextContent = ".custom-code { background-color: #f0f0f0; color: #c7254e; font-family: Consolas, \"Courier New\", monospace; padding: 2px 4px; border-radius: 4px; }";

            // Append the style element to <head>
            HTMLElement head = (HTMLElement)document.GetElementsByTagName("head")[0];
            head.AppendChild(style);

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);

            Console.WriteLine($"Document saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}