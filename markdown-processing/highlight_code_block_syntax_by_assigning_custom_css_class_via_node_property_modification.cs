// Highlight code block syntax by assigning a custom CSS class through node property modification.

using System;
using System.IO;
using System.Linq;
using System.Text;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML with a code block
            string htmlContent = @"
<!DOCTYPE html>
<html>
<head>
    <title>Sample</title>
</head>
<body>
    <h1>Example</h1>
    <pre><code>Console.WriteLine(""Hello, World!"");</code></pre>
</body>
</html>";
            string inputPath = "sample.html";
            string outputPath = "output.html";

            // Write the sample HTML to a file
            File.WriteAllText(inputPath, htmlContent, Encoding.UTF8);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Create a style element with custom CSS class for code blocks
            Aspose.Html.Dom.Element styleElement = document.CreateElement("style");
            styleElement.TextContent = ".custom-code { background-color: #f0f0f0; font-family: Consolas, monospace; }";

            // Append the style element to the head
            Aspose.Html.Dom.Element head = document.GetElementsByTagName("head").First();
            head.AppendChild(styleElement);

            // Find all <code> elements and assign the custom CSS class
            Aspose.Html.Collections.NodeList codeElements = document.QuerySelectorAll("code");
            foreach (Aspose.Html.HTMLElement element in codeElements)
            {
                element.SetAttribute("class", "custom-code");
            }

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}