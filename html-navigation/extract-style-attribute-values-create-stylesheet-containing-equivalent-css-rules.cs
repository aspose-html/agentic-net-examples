// Extract all style attribute values and create a stylesheet file containing equivalent CSS rules.

using System;
using System.Text;
using System.IO;
using Aspose.Html.Collections;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = @"
                <html>
                    <head><title>Sample</title></head>
                    <body>
                        <div style=""color:red; font-size:14px;"">Hello</div>
                        <p style=""margin:10px; background:#f0f0f0;"">World</p>
                        <span>No style here</span>
                    </body>
                </html>";

            // Load HTML document from inline content
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Select all elements that have a style attribute
            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("[style]");

            var cssBuilder = new StringBuilder();

            int index = 0;
            foreach (Aspose.Html.HTMLElement element in elements)
            {
                // Get the style attribute value
                string styleValue = element.GetAttribute("style");
                if (string.IsNullOrEmpty(styleValue))
                    continue;

                // Create a unique class name
                string className = $"extracted-style-{index}";

                // Preserve existing class attribute if any
                string existingClass = element.GetAttribute("class");
                string newClass = string.IsNullOrEmpty(existingClass) ? className : $"{existingClass} {className}";
                element.SetAttribute("class", newClass);

                // Remove the inline style attribute
                element.RemoveAttribute("style");

                // Append CSS rule to the stylesheet content
                cssBuilder.AppendLine($".{className} {{{styleValue}}}");

                index++;
            }

            // Write the generated CSS to a file
            string cssPath = "extracted-styles.css";
            File.WriteAllText(cssPath, cssBuilder.ToString());

            // Optionally, save the modified HTML document
            string htmlPath = "modified.html";
            document.Save(htmlPath);

            Console.WriteLine($"Extracted CSS saved to: {Path.GetFullPath(cssPath)}");
            Console.WriteLine($"Modified HTML saved to: {Path.GetFullPath(htmlPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}