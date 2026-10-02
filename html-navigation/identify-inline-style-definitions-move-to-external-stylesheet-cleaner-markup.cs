// Identify inline style definitions and move them to an external stylesheet for cleaner markup.

using System;
using System.IO;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with inline styles
            string htmlContent = "<html><head></head><body>" +
                                 "<p style=\"color:red; font-size:14px;\">Hello World</p>" +
                                 "<div style=\"background:#eee; padding:10px;\">Sample Box</div>" +
                                 "</body></html>";

            // Load HTML document from string using two‑argument constructor (content, baseUri)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Find all elements that have a style attribute
            Aspose.Html.Collections.NodeList elementsWithStyle = document.QuerySelectorAll("[style]");

            StringBuilder cssBuilder = new StringBuilder();
            int index = 0;

            foreach (Aspose.Html.Dom.Element element in elementsWithStyle)
            {
                string inlineStyle = element.GetAttribute("style");
                if (string.IsNullOrEmpty(inlineStyle))
                    continue;

                string className = $"inlineStyle{index}";
                string existingClass = element.GetAttribute("class");
                string newClass = string.IsNullOrEmpty(existingClass) ? className : $"{existingClass} {className}";
                element.SetAttribute("class", newClass);
                element.RemoveAttribute("style");

                cssBuilder.AppendLine($".{className} {{{inlineStyle}}}");
                index++;
            }

            // Create a <style> element with the collected CSS
            Aspose.Html.Dom.Element styleElement = document.CreateElement("style");
            styleElement.TextContent = cssBuilder.ToString();

            // Append the style element to <head>
            Aspose.Html.Dom.Element head = document.GetElementsByTagName("head").First() as Aspose.Html.Dom.Element;
            if (head != null)
            {
                head.AppendChild(styleElement);
            }

            // Save the modified document
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
            document.Save(outputPath);

            Console.WriteLine($"Document saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}