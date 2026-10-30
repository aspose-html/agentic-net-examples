// Extract all anchor elements that open in a new window (target="_blank") for security review.

using System;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlContent = "<html><body>" +
                    "<a href=\"https://example.com\" target=\"_blank\">Example</a>" +
                    "<a href=\"https://test.com\">Test</a>" +
                    "<a href=\"https://blank.com\" target=\"_blank\">Blank</a>" +
                    "</body></html>";

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
                {
                    Aspose.Html.Collections.HTMLCollection anchors = document.GetElementsByTagName("a");
                    for (int i = 0; i < anchors.Length; i++)
                    {
                        Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)anchors[i];
                        string target = element.GetAttribute("target");
                        if (string.Equals(target, "_blank", StringComparison.OrdinalIgnoreCase))
                        {
                            string href = element.GetAttribute("href");
                            string text = element.TextContent != null ? element.TextContent.Trim() : string.Empty;
                            Console.WriteLine($"Href: {href}, Text: {text}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}