// Replace all occurrences of a deprecated attribute (e.g., align) with equivalent CSS styling.

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
            // Sample HTML with deprecated align attributes
            string htmlContent = "<html><body>" +
                                 "<p align=\"center\">Centered paragraph.</p>" +
                                 "<div align=\"right\">Right-aligned div.</div>" +
                                 "<table align=\"left\"><tr><td>Left-aligned table.</td></tr></table>" +
                                 "</body></html>";

            // Load HTML from string (inline content)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Select all elements that have an 'align' attribute
            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("[align]");

            // Replace 'align' attribute with equivalent CSS styling
            foreach (Aspose.Html.HTMLElement element in elements)
            {
                string alignValue = element.GetAttribute("align");
                element.RemoveAttribute("align");
                // Apply CSS text-align based on the original attribute value
                element.Style.TextAlign = alignValue;
            }

            // Save the modified document
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
            document.Save(outputPath);

            Console.WriteLine($"HTML processed and saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}