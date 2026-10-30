// Replace deprecated <font> tags with equivalent CSS style attributes throughout the document.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML containing <font> tags
            string htmlContent = "<html><body><font color=\"red\" size=\"4\" face=\"Arial\">Hello</font> world.</body></html>";

            // Load HTML from string (inline content)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get all <font> elements
            Aspose.Html.Collections.HTMLCollection fontElements = document.GetElementsByTagName("font");

            // Iterate in reverse order to safely replace nodes
            for (int i = fontElements.Length - 1; i >= 0; i--)
            {
                Aspose.Html.HTMLElement font = (Aspose.Html.HTMLElement)fontElements[i];

                // Retrieve font attributes
                string color = font.GetAttribute("color");
                string size = font.GetAttribute("size");
                string face = font.GetAttribute("face");

                // Build equivalent CSS style
                string style = "";
                if (!string.IsNullOrEmpty(color))
                {
                    style += $"color:{color};";
                }
                if (!string.IsNullOrEmpty(size))
                {
                    // Simple mapping: treat size as points
                    style += $"font-size:{size}pt;";
                }
                if (!string.IsNullOrEmpty(face))
                {
                    style += $"font-family:{face};";
                }

                // Create a <span> element with the same inner HTML and style
                Aspose.Html.HTMLElement span = (Aspose.Html.HTMLElement)document.CreateElement("span");
                span.SetAttribute("style", style);
                span.InnerHTML = font.InnerHTML;

                // Replace the <font> element with the new <span>
                font.ParentNode.ReplaceChild(span, font);
            }

            // Save the modified document
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