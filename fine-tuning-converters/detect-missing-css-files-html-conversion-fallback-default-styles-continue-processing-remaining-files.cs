// Detect missing CSS files during HTML conversion, fallback to default styles, and continue processing remaining files.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define sample HTML files
            string[] inputFiles = new string[] { "sample1.html", "sample2.html" };
            string outputDirectory = "output";
            Directory.CreateDirectory(outputDirectory);

            // Create minimal sample files if they do not exist
            foreach (string inputPath in inputFiles)
            {
                if (!File.Exists(inputPath))
                {
                    string sampleContent = @"<!DOCTYPE html>
<html>
<head>
    <link rel=""stylesheet"" href=""missing.css"">
    <title>Test Document</title>
</head>
<body>
    <h1>Hello World</h1>
</body>
</html>";
                    File.WriteAllText(inputPath, sampleContent);
                }
            }

            // Process each HTML file
            foreach (string inputPath in inputFiles)
            {
                Console.WriteLine($"Processing '{inputPath}'...");

                // Load the HTML document
                HTMLDocument document = new HTMLDocument(inputPath);

                // Detect missing CSS files and apply fallback
                HTMLCollection linkElements = document.GetElementsByTagName("link");
                for (int i = 0; i < linkElements.Length; i++)
                {
                    Element element = linkElements[i] as Element;
                    HTMLElement link = element as HTMLElement;
                    if (link != null && link.GetAttribute("rel") == "stylesheet")
                    {
                        string href = link.GetAttribute("href");
                        string cssPath = Path.Combine(Path.GetDirectoryName(inputPath) ?? string.Empty, href);
                        if (!File.Exists(cssPath))
                        {
                            Console.WriteLine($"  Missing CSS: '{href}'. Removing link and adding default style.");

                            // Remove the missing link element
                            link.ParentNode.RemoveChild(link);

                            // Create a default style element
                            Element styleElement = document.CreateElement("style");
                            HTMLElement style = styleElement as HTMLElement;
                            if (style != null)
                            {
                                style.InnerHTML = "body { font-family: Arial; }";

                                // Append the style to the head element
                                HTMLCollection headElements = document.GetElementsByTagName("head");
                                if (headElements.Length > 0)
                                {
                                    Element head = headElements[0] as Element;
                                    if (head != null)
                                    {
                                        head.AppendChild(style);
                                    }
                                }
                            }
                        }
                    }
                }

                // Convert the document to XPS
                XpsSaveOptions options = new XpsSaveOptions();
                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".xps");
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

                Console.WriteLine($"  Converted to '{outputPath}'.");
            }

            Console.WriteLine("Processing completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}