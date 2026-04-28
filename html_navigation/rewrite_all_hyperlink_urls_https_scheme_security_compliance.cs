// Rewrite all hyperlink URLs to use HTTPS scheme for improved security compliance.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

namespace HyperlinkHttpsRewriter
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

                // Iterate over all hyperlink elements in the document
                foreach (Element linkElement in document.Links)
                {
                    // Get the current href attribute
                    string href = linkElement.GetAttribute("href");
                    if (string.IsNullOrEmpty(href))
                        continue;

                    // Replace http scheme with https if present
                    if (href.StartsWith("http://", StringComparison.OrdinalIgnoreCase))
                    {
                        string httpsHref = "https://" + href.Substring(7);
                        linkElement.SetAttribute("href", httpsHref);
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