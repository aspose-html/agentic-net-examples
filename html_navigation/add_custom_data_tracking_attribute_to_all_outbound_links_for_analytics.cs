// Add a custom data‑tracking attribute to all outbound links for analytics purposes.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

namespace HtmlLinkTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input HTML file path
                string inputPath = "input.html";
                // Output HTML file path
                string outputPath = "output.html";

                // Load the HTML document
                HTMLDocument document = new HTMLDocument(inputPath);

                // Iterate over all anchor elements with href attribute
                HTMLCollection links = document.Links;
                for (int i = 0; i < links.Length; i++)
                {
                    Element link = links[i] as Element;
                    if (link == null) continue;

                    string href = link.GetAttribute("href");
                    if (string.IsNullOrEmpty(href)) continue;

                    // Consider outbound links (starting with http or https)
                    if (href.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                        href.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                    {
                        // Add custom data‑tracking attribute
                        link.SetAttribute("data-tracking", "analytics");
                    }
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