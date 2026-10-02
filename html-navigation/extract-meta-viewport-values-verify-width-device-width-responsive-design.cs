// Extract all meta viewport values and verify they contain width=device‑width for responsive design.

using System;
using Aspose.Html;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content with meta viewport tags
            string htmlContent = @"
                <html>
                    <head>
                        <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
                        <meta name=""viewport"" content=""height=800"">
                        <meta charset=""utf-8"">
                    </head>
                    <body>
                        <p>Hello, world!</p>
                    </body>
                </html>";

            // Load HTML document from string (inline content)
            using (HTMLDocument document = new HTMLDocument(htmlContent, "about:blank"))
            {
                // Get all <meta> elements
                Aspose.Html.Collections.HTMLCollection elements = document.GetElementsByTagName("meta");

                bool viewportFound = false;

                for (int i = 0; i < elements.Length; i++)
                {
                    Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)elements[i];
                    string nameAttr = element.GetAttribute("name");
                    if (!string.IsNullOrEmpty(nameAttr) && 
                        string.Equals(nameAttr, "viewport", StringComparison.OrdinalIgnoreCase))
                    {
                        viewportFound = true;
                        string contentAttr = element.GetAttribute("content") ?? string.Empty;
                        bool hasWidthDeviceWidth = contentAttr
                            .IndexOf("width=device-width", StringComparison.OrdinalIgnoreCase) >= 0;

                        Console.WriteLine($"Viewport meta tag content: \"{contentAttr}\"");
                        Console.WriteLine($"Contains width=device-width: {hasWidthDeviceWidth}");
                    }
                }

                if (!viewportFound)
                {
                    Console.WriteLine("No meta viewport tags were found in the document.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}