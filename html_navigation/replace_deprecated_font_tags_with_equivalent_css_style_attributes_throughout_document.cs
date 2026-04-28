// Replace deprecated <font> tags with equivalent CSS style attributes throughout the document.

using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Svg;

namespace ReplaceFontTags
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input and output HTML file paths
                string inputPath = "input.html";
                string outputPath = "output.html";

                // Load the HTML document
                HTMLDocument document = new HTMLDocument(inputPath);

                // Get all <font> elements in the document
                var fontElements = document.GetElementsByTagName("font").Cast<HTMLFontElement>().ToList();

                // Replace each <font> element with an equivalent <span> having inline CSS
                foreach (HTMLFontElement font in fontElements)
                {
                    var styleParts = new List<string>();

                    // Map deprecated attributes to CSS
                    if (!string.IsNullOrEmpty(font.Color))
                        styleParts.Add($"color:{font.Color}");
                    if (!string.IsNullOrEmpty(font.Face))
                        styleParts.Add($"font-family:{font.Face}");
                    if (!string.IsNullOrEmpty(font.Size))
                        styleParts.Add($"font-size:{font.Size}px");

                    string style = string.Join(";", styleParts);

                    // Preserve inner HTML of the original <font> element
                    string innerContent = font.InnerHTML;

                    // Build replacement <span> element
                    string replacement = $"<span style=\"{style}\">{innerContent}</span>";

                    // Replace the original element in the DOM
                    font.OuterHTML = replacement;
                }

                // Save the modified document
                document.Save(outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}