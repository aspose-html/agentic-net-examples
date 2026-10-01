// Remove all inline style attributes from elements to enforce external stylesheet usage.

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
            // Define input and output file paths
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Ensure a minimal input HTML file exists
            if (!File.Exists(inputPath))
            {
                string sampleHtml = @"<!DOCTYPE html>
<html>
<head>
    <title>Sample</title>
</head>
<body onclick=""alert('test')"">
    <h1>Hello World</h1>
</body>
</html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(inputPath);

            // Remove background-color style from body if present
            Aspose.Html.HTMLElement body = (Aspose.Html.HTMLElement)document.GetElementsByTagName("body").First();
            body.Style.RemoveProperty("background-color");

            // Create a <style> element with new background color
            Aspose.Html.Dom.Element style = document.CreateElement("style");
            style.TextContent = "body { background-color: rgb(229, 243, 253) }";

            // Append the style element to <head>
            Aspose.Html.Dom.Element head = document.GetElementsByTagName("head").First();
            head.AppendChild(style);

            // Remove all "onclick" attributes from elements
            var elements = document.QuerySelectorAll("[onclick]");
            for (int i = 0; i < elements.Length; i++)
            {
                Aspose.Html.Dom.Element el = (Aspose.Html.Dom.Element)elements[i];
                string val = el.GetAttribute("onclick");
                if (!string.IsNullOrEmpty(val))
                {
                    el.RemoveAttribute("onclick");
                }
            }

            // Save the modified document
            document.Save(outputPath);

            Console.WriteLine($"Document processed and saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}