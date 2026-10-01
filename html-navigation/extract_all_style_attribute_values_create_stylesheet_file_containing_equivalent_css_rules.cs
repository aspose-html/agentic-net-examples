// Extract all style attribute values and create a stylesheet file containing equivalent CSS rules.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content with inline styles
            string htmlContent = @"<!DOCTYPE html>
<html>
<head></head>
<body>
    <div style=""color:red; background:#fff;"">Test</div>
    <p style=""font-size:14px;"">Paragraph</p>
    <span style=""margin:5px; padding:2px;"">Span text</span>
</body>
</html>";

            // Write the sample HTML to a temporary file
            string htmlPath = "sample.html";
            File.WriteAllText(htmlPath, htmlContent, Encoding.UTF8);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Select all elements that have a style attribute
            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("[style]");

            // Build CSS rules from the extracted style attributes
            StringBuilder cssBuilder = new StringBuilder();

            foreach (Aspose.Html.HTMLElement element in elements)
            {
                // Get the tag name of the element
                string tagName = ((Aspose.Html.Dom.Element)element).TagName;

                // Get the value of the style attribute
                string styleValue = element.GetAttribute("style");

                // Append a CSS rule for this tag
                cssBuilder.AppendLine($"{tagName} {{{styleValue}}}");
            }

            // Write the generated CSS to a stylesheet file
            string cssPath = "extracted-styles.css";
            File.WriteAllText(cssPath, cssBuilder.ToString(), Encoding.UTF8);

            Console.WriteLine($"CSS stylesheet generated at: {Path.GetFullPath(cssPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}