// Create a style element, define a CSS variable for primary color, and use it in multiple rules.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Inline HTML content
            string htmlContent = "<!DOCTYPE html><html><head></head><body></body></html>";
            // Create document from inline content
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Create <style> element
            Aspose.Html.Dom.Element style = document.CreateElement("style");
            style.TextContent = @"
:root {
    --primary-color: #3498db;
}
.header {
    color: var(--primary-color);
}
.button {
    background-color: var(--primary-color);
}";

            // Append style to <head>
            Aspose.Html.HTMLElement head = (Aspose.Html.HTMLElement)document.QuerySelector("head");
            head.AppendChild(style);

            // Save the resulting HTML to a file
            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine($"HTML document saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}