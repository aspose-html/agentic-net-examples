// Inline external CSS files into style tags within the HTML head for a self‑contained document.

using System;
using System.IO;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            string inputHtmlPath = "input.html";
            string cssPath = "styles.css";
            string outputHtmlPath = "output.html";

            // Create sample CSS file if it does not exist
            if (!File.Exists(cssPath))
            {
                File.WriteAllText(cssPath, "body { background-color: #f0f0f0; }");
            }

            // Create sample HTML file referencing the CSS file
            if (!File.Exists(inputHtmlPath))
            {
                string sampleHtml = @"<!DOCTYPE html>
<html>
<head>
    <link rel=""stylesheet"" href=""styles.css"">
</head>
<body>
    <p>Hello World</p>
</body>
</html>";
                File.WriteAllText(inputHtmlPath, sampleHtml);
            }

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputHtmlPath);

            // Get the <head> element
            Element head = (Element)document.GetElementsByTagName("head").First();

            // Get all <link> elements
            HTMLCollection links = document.GetElementsByTagName("link");

            // Iterate backwards to safely modify the DOM
            for (int i = links.Length - 1; i >= 0; i--)
            {
                HTMLElement link = (HTMLElement)links[i];
                string rel = link.GetAttribute("rel");
                if (string.Equals(rel, "stylesheet", StringComparison.OrdinalIgnoreCase))
                {
                    string href = link.GetAttribute("href");
                    if (!string.IsNullOrEmpty(href) && File.Exists(href))
                    {
                        string cssContent = File.ReadAllText(href);

                        // Create a <style> element with the CSS content
                        HTMLElement style = (HTMLElement)document.CreateElement("style");
                        style.TextContent = cssContent;

                        // Replace the <link> element with the new <style> element
                        head.ReplaceChild(style, link);
                    }
                }
            }

            // Save the modified document
            document.Save(outputHtmlPath);

            Console.WriteLine($"Inlined CSS saved to '{outputHtmlPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}