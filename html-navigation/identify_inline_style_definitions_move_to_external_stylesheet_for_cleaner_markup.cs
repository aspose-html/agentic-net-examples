// Identify inline style definitions and move them to an external stylesheet for cleaner markup.

using System;
using System.IO;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML with inline styles
            string inputPath = "input.html";
            string outputPath = "output.html";
            string htmlContent = @"
<!DOCTYPE html>
<html>
<head>
    <title>Sample</title>
</head>
<body>
    <h1 style=""color: red; font-size: 24px;"">Hello World</h1>
    <p style=""margin: 10px; line-height: 1.5;"">This is a paragraph.</p>
    <div style=""background-color: #f0f0f0; padding: 5px;"">A div element.</div>
</body>
</html>";
            File.WriteAllText(inputPath, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Collect CSS rules
            var cssBuilder = new System.Text.StringBuilder();
            int classCounter = 1;

            // Iterate over all elements with a style attribute
            var allElements = document.GetElementsByTagName("*");
            foreach (Aspose.Html.Dom.Element element in allElements)
            {
                string styleValue = element.GetAttribute("style");
                if (!string.IsNullOrEmpty(styleValue))
                {
                    string className = "cls" + classCounter++;
                    // Assign new class
                    element.SetAttribute("class", className);
                    // Remove inline style
                    element.SetAttribute("style", "");
                    // Append CSS rule
                    cssBuilder.AppendLine($".{className} {{ {styleValue} }}");
                }
            }

            // Create style element with collected CSS
            Aspose.Html.Dom.Element styleElement = document.CreateElement("style");
            styleElement.TextContent = cssBuilder.ToString();

            // Append style element to head
            Aspose.Html.Dom.Element head = document.GetElementsByTagName("head").First();
            head.AppendChild(styleElement);

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}