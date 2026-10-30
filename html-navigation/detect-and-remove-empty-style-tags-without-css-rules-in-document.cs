// Detect and remove empty style tags that contain no CSS rules in the document.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with empty and non‑empty style tags
            string htmlContent = @"
                <html>
                    <head>
                        <style></style>
                        <style>
                            body { background-color: #f0f0f0; }
                        </style>
                    </head>
                    <body>
                        <p>Hello, World!</p>
                    </body>
                </html>";

            // Load HTML from string (inline content)
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get all <style> elements
            Aspose.Html.Collections.HTMLCollection styles = document.GetElementsByTagName("style");

            // Iterate backwards to safely remove elements while iterating
            for (int i = styles.Length - 1; i >= 0; i--)
            {
                var styleElement = (Aspose.Html.Dom.Element)styles[i];
                if (string.IsNullOrWhiteSpace(styleElement.TextContent))
                {
                    // Remove empty <style> tag from its parent
                    styleElement.ParentNode.RemoveChild(styleElement);
                }
            }

            // Save the cleaned HTML to a file
            string outputPath = "cleaned.html";
            document.Save(outputPath);

            Console.WriteLine($"Empty <style> tags removed. Cleaned HTML saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}