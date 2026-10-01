// Load an HTML file from disk, change body background color, and overwrite the original file.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input HTML file
            string inputPath = "sample.html";
            string outputPath = "output.html";

            if (!File.Exists(inputPath))
            {
                string sampleHtml = @"<!DOCTYPE html>
<html>
<head>
    <title>Sample</title>
</head>
<body>
    <p>Hello, Aspose.HTML!</p>
</body>
</html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the document
            var document = new Aspose.Html.HTMLDocument(inputPath);

            // Access the <body> element and change its background color
            var bodyElement = (Aspose.Html.HTMLElement)document.GetElementsByTagName("body")[0];
            bodyElement.Style.BackgroundColor = "lightblue";

            // Add a <style> element to the <head>
            var styleElement = (Aspose.Html.HTMLElement)document.CreateElement("style");
            styleElement.TextContent = "p { background-color: rgb(229, 243, 253); }";
            var headElement = (Aspose.Html.HTMLElement)document.GetElementsByTagName("head")[0];
            headElement.AppendChild(styleElement);

            // Set a custom attribute on the body
            bodyElement.SetAttribute("data-example", "true");

            // Save the modified document
            document.Save(outputPath);

            Console.WriteLine($"Document processed and saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}