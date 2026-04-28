// Extract all meta viewport values and verify they contain width=device‑width for responsive design.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the HTML file to be analyzed
            string htmlPath = "input.html";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Retrieve all <meta> elements
            var metaNodes = document.GetElementsByTagName("meta");

            bool allResponsive = true;

            // Iterate through each <meta> element
            foreach (Element node in metaNodes)
            {
                // Cast to HTMLMetaElement to access meta-specific properties
                if (node is HTMLMetaElement meta)
                {
                    // Check for viewport meta tag
                    if (meta.Name != null && meta.Name.Equals("viewport", StringComparison.OrdinalIgnoreCase))
                    {
                        string content = meta.Content ?? string.Empty;
                        Console.WriteLine($"Viewport meta content: {content}");

                        // Verify that the content includes width=device-width
                        if (!content.Contains("width=device-width", StringComparison.OrdinalIgnoreCase))
                        {
                            allResponsive = false;
                            Console.WriteLine("-> Missing width=device-width in viewport meta.");
                        }
                    }
                }
            }

            Console.WriteLine(allResponsive
                ? "All viewport meta tags contain width=device-width."
                : "One or more viewport meta tags are missing width=device-width.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}