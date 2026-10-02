// Replace deprecated <font> tags with equivalent CSS style attributes throughout the document.

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML containing deprecated <font> tags
            string htmlContent = "<html><body><font color=\"red\" face=\"Arial\" size=\"4\">Hello World</font></body></html>";

            // Load HTML from string using two‑argument constructor (content, baseUri)
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Collect all <font> elements
            var fontElements = new List<Aspose.Html.HTMLElement>();
            foreach (var node in document.GetElementsByTagName("font"))
            {
                if (node is Aspose.Html.HTMLElement font)
                {
                    fontElements.Add(font);
                }
            }

            // Replace each <font> with a <span> that has equivalent CSS styles
            foreach (var font in fontElements)
            {
                var span = (Aspose.Html.HTMLElement)document.CreateElement("span");
                span.InnerHTML = font.InnerHTML;

                var style = string.Empty;
                if (font.HasAttribute("color"))
                {
                    style += $"color:{font.GetAttribute("color")};";
                }
                if (font.HasAttribute("face"))
                {
                    style += $"font-family:{font.GetAttribute("face")};";
                }
                if (font.HasAttribute("size"))
                {
                    // Simple conversion: treat size value as pixel size
                    style += $"font-size:{font.GetAttribute("size")}px;";
                }

                if (!string.IsNullOrEmpty(style))
                {
                    span.SetAttribute("style", style);
                }

                var parent = font.ParentNode;
                parent.ReplaceChild(span, font);
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