// Add a custom data‑tracking attribute to all outbound links for analytics purposes.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body>" +
                                 "<a href=\"https://example.com\">External Link</a>" +
                                 "<a href=\"/local\">Local Link</a>" +
                                 "</body></html>";

            // Load the document from the HTML string
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                // Select all anchor elements with href attribute
                Aspose.Html.Collections.NodeList anchors = document.QuerySelectorAll("a[href]");

                foreach (Aspose.Html.Dom.Node node in anchors)
                {
                    Aspose.Html.HTMLElement element = node as Aspose.Html.HTMLElement;
                    if (element != null)
                    {
                        string href = element.GetAttribute("href");
                        if (!string.IsNullOrEmpty(href) &&
                            (href.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                             href.StartsWith("https://", StringComparison.OrdinalIgnoreCase)))
                        {
                            // Add custom data-tracking attribute
                            element.SetAttribute("data-tracking", Guid.NewGuid().ToString());
                        }
                    }
                }

                // Save the modified HTML to a file
                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine($"Modified HTML saved to: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}