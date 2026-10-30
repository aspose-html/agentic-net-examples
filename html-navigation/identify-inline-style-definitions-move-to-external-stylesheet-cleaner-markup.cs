// Identify inline style definitions and move them to an external stylesheet for cleaner markup.

using System;
using System.Text;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with inline styles
            string htmlContent = "<html><head></head><body>" +
                                 "<p style=\"color:red; font-size:14px;\">Hello</p>" +
                                 "<div style=\"margin:10px; background-color:lightblue;\">World</div>" +
                                 "</body></html>";

            // Load HTML document from string (use two-argument constructor)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Build CSS rules extracted from inline styles
            StringBuilder cssBuilder = new StringBuilder();
            int styleIndex = 0;

            // Find all elements with a 'style' attribute
            Aspose.Html.Collections.NodeList nodesWithStyle = document.QuerySelectorAll("[style]");
            foreach (Node node in nodesWithStyle)
            {
                Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)node;
                string inlineStyle = element.GetAttribute("style");
                if (string.IsNullOrWhiteSpace(inlineStyle))
                    continue;

                // Create a unique class name
                string className = $"extracted-style-{styleIndex}";
                styleIndex++;

                // Append the class to existing class attribute if any
                string existingClass = element.GetAttribute("class");
                string newClass = string.IsNullOrEmpty(existingClass) ? className : existingClass + " " + className;
                element.SetAttribute("class", newClass);

                // Remove the inline style attribute
                element.RemoveAttribute("style");

                // Add CSS rule for the new class
                cssBuilder.AppendLine($".{className} {{{inlineStyle}}}");
            }

            // Create a <style> element with the extracted CSS
            Aspose.Html.Dom.Element styleElement = document.CreateElement("style");
            styleElement.TextContent = cssBuilder.ToString();

            // Append the <style> element to <head>
            Aspose.Html.HTMLElement head = (Aspose.Html.HTMLElement)document.GetElementsByTagName("head").First();
            head.AppendChild(styleElement);

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);

            Console.WriteLine($"HTML saved to '{outputPath}'. Inline styles have been moved to an external stylesheet.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}