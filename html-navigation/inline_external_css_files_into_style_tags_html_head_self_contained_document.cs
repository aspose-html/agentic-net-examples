// Inline external CSS files into style tags within the HTML head for a self‑contained document.

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample files
            string inputHtmlPath = "input.html";
            string cssPath = "style.css";
            string outputHtmlPath = "output.html";

            // Write sample CSS
            File.WriteAllText(cssPath, "body { background-color: #e5f3fd; } p { color: #333333; }");

            // Write sample HTML referencing external CSS
            string htmlContent = @"<!DOCTYPE html>
<html>
<head>
    <link rel=""stylesheet"" href=""style.css"">
</head>
<body>
    <p>Hello, Aspose.HTML!</p>
</body>
</html>";
            File.WriteAllText(inputHtmlPath, htmlContent);

            // Load HTML document
            HTMLDocument document = new HTMLDocument(inputHtmlPath);

            // Find all <link rel=""stylesheet""> elements
            List<Element> linkElements = Enumerable.ToList(document.GetElementsByTagName("link"));
            foreach (Element linkElement in linkElements)
            {
                HTMLElement link = (HTMLElement)linkElement;
                if (string.Equals(link.GetAttribute("rel"), "stylesheet", StringComparison.OrdinalIgnoreCase))
                {
                    string href = link.GetAttribute("href");
                    string cssFullPath = Path.Combine(Path.GetDirectoryName(inputHtmlPath) ?? "", href);
                    if (File.Exists(cssFullPath))
                    {
                        string cssContent = File.ReadAllText(cssFullPath);

                        // Create <style> element with inlined CSS
                        HTMLElement style = (HTMLElement)document.CreateElement("style");
                        style.TextContent = cssContent;

                        // Append style to <head>
                        HTMLElement head = (HTMLElement)Enumerable.First(document.GetElementsByTagName("head"));
                        head.AppendChild(style);

                        // Remove the original <link> element
                        link.ParentNode.RemoveChild(link);
                    }
                }
            }

            // Save the self‑contained HTML document
            document.Save(outputHtmlPath);
            Console.WriteLine($"Inlined HTML saved to: {outputHtmlPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}