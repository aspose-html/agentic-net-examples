// Remove all inline style attributes from elements to enforce external stylesheet usage.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with inline styles
            string htmlContent = @"<!DOCTYPE html>
<html>
<head>
    <title>Sample</title>
</head>
<body>
    <div style=""color:red; font-size:14px;"">Hello World</div>
    <p style=""margin:10px;"">Paragraph with style.</p>
    <span>No style here.</span>
</body>
</html>";

            // Load HTML document from string (using two-argument constructor)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Select all elements that have a 'style' attribute
            var elementsWithStyle = document.QuerySelectorAll("[style]");

            // Remove the inline 'style' attribute from each element
            for (int i = 0; i < elementsWithStyle.Length; i++)
            {
                Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)elementsWithStyle[i];
                element.RemoveAttribute("style");
            }

            // Define output path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");

            // Save the modified document
            document.Save(outputPath);

            Console.WriteLine($"Document saved successfully to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}