// Define an internal CSS rule to set the body background-color for the entire page and save.

using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a minimal HTML file as input
            string inputPath = "input.html";
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath,
@"<!DOCTYPE html>
<html>
<head>
    <title>Sample</title>
</head>
<body>
    <h1>Hello, Aspose.HTML!</h1>
</body>
</html>");
            }

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(inputPath);

            // Remove existing background-color from body style
            var body = (Aspose.Html.HTMLElement)document.GetElementsByTagName("body").First();
            body.Style.RemoveProperty("background-color");

            // Add a new style element to set a specific background color
            Aspose.Html.Dom.Element style = document.CreateElement("style");
            style.TextContent = "body { background-color: rgb(229, 243, 253) }";

            // Append the style element to the head
            var head = (Aspose.Html.HTMLElement)document.GetElementsByTagName("head").First();
            head.AppendChild(style);

            // Optionally set a background image on the body using QuerySelector
            Aspose.Html.Dom.Element bodyElement = document.QuerySelector("body");
            if (bodyElement != null)
            {
                bodyElement.SetAttribute("style", "background-image: url('flower.png');");
            }

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);

            Console.WriteLine($"Document processed and saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}