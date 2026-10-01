// Add a custom data‑tracking attribute to all outbound links for analytics purposes.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body>" +
                                 "<a href=\"https://external.com/page\">External Link</a>" +
                                 "<a href=\"/internal/page\">Internal Link</a>" +
                                 "</body></html>";

            // Load HTML into Aspose.Html.HTMLDocument
            var document = new Aspose.Html.HTMLDocument(htmlContent);

            // Get all anchor elements
            var anchors = document.GetElementsByTagName("a");

            foreach (Aspose.Html.Dom.Element anchor in anchors)
            {
                string href = anchor.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;

                bool isOutbound = false;
                if (href.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                    href.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        var uri = new Uri(href);
                        // Replace "example.com" with your own domain as needed
                        if (!uri.Host.Equals("example.com", StringComparison.OrdinalIgnoreCase))
                        {
                            isOutbound = true;
                        }
                    }
                    catch
                    {
                        // Invalid URI, treat as non‑outbound
                    }
                }

                if (isOutbound)
                {
                    // Add custom data‑tracking attribute
                    anchor.SetAttribute("data-tracking", "analytics123");
                }
            }

            // Save the modified document
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}