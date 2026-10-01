// Locate an element by ID with GetElementById and apply an inline border-color style.

using System;
using System.IO;
using System.Linq;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string inputPath = Path.Combine(Path.GetTempPath(), "sample.html");
            string outputPath = Path.Combine(Path.GetTempPath(), "output.html");

            string htmlContent = @"
<!DOCTYPE html>
<html>
<head>
    <style>
        h1 { font-size:20px; }
    </style>
</head>
<body>
    <h1>Hello World</h1>
</body>
</html>";

            File.WriteAllText(inputPath, htmlContent);

            // Load the document
            var document = new Aspose.Html.HTMLDocument(inputPath);

            // Modify the first <h1> element's border
            var header = (Aspose.Html.HTMLElement)document.GetElementsByTagName("h1").First();
            header.Style.BorderStyle = "solid";
            header.Style.BorderColor = "red";

            // Append additional CSS to the existing <style> element
            var styleElement = (Aspose.Html.HTMLElement)document.QuerySelector("style");
            styleElement.TextContent = styleElement.InnerHTML + "h1 { color: blue; }";

            // Set a custom attribute on the <body> element
            var body = (Aspose.Html.HTMLElement)document.QuerySelector("body");
            body.SetAttribute("data-sample", "value");

            // Save the modified document
            document.Save(outputPath);

            Console.WriteLine($"Document processed and saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}